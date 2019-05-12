<?php
ini_set('max_execution_time', 900);
/**
 * Logic short summary.
 *
 * Logic description.
 *
 * @version 1.0
 * @author ioffe
 */
class Logic
{

    private function substring_finder($sub_str, $str)
    {
        $prefix_string = $sub_str."@".$str;
        $prefix_array = $this->compute_prefix_function($prefix_string);

        $isfind = false;
        foreach($prefix_array as $item)
        {
            if ($item == mb_strlen($sub_str))
            {
                $isfind = true;
                break;
            }

        }

        return $isfind;
    }

    private function compute_prefix_function($str)
    {
    $prefix_array = array(); // значения префикс-функции
    $prefix_array[0] = 0;
    $k = 0;
    $j = 0;
    $i = 1;
    while ($i<mb_strlen($str))
    {
        if ($str[$i] == $str[$j])
        {
            $prefix_array[$i]=$j+1;
            $i++;
            $j++;
        }
        else if ($j == 0)
        {
            $prefix_array[$i] =0;
            $i++;
        }
        else
            $j=$prefix_array[$j-1];
    }
    return $prefix_array;
}

    public function find_strings_in_files_in_directory($path, $string_to_find)
    {

        $content = explode(";", $this ->get_directories($path));

       // && strpos($item,".") === false
        $result = array();

        foreach ($content as $item)
        {
            //TODO add more file types, str after str exit
            if (strpos($item,".txt") !== false || strpos($item,".TXT") !== false)
                $result[$path . $item] = $this ->find_string_in_file($path . $item, $string_to_find);
            else if ($item != "")
                $result = array_merge($result, $this -> find_strings_in_files_in_directory($path . $item . "/", $string_to_find));
        }
        return $result;
    }

    private function find_string_in_file($path, $string_to_find)
    {
        $rows = "";

        $file = fopen($path, "r");

        $row = 1;
        while(!feof($file))
        {
            $str = fgets($file);
            if ($this ->substring_finder($string_to_find, $str))
                $rows .= $row.";";
            $row++;
        }

        fclose($file);
        return $rows;
    }

    public function get_directories ($path)
    {
        if (file_exists($path) && is_dir($path) && is_readable($path))
                $dirsarray = scandir($path);
            else
                return "";


        $dirsstring = "";
        foreach ($dirsarray as $item)
        {
            if ($item == "." || $item == "..")
                continue;

            $dirsstring .= $item.";";
        }

        return $dirsstring;
    }
}
?>