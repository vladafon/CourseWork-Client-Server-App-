<?php

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
                $isfind = true;
        }

        return $isfind;
    }

    private function compute_prefix_function($str)
    {
    $prefix_array = array(); // значения префикс-функции
                                 // индекс листа соответствует номеру последнего символа аргумента
    $k = 0;
    for ($i = 1; $i < mb_strlen($str); ++$i) {
        while (($k > 0) && ($str[$k] != $str[$i]))
        {
            if ($k-1 <= 0 || $k-1 > count($prefix_array))
                $k = 0;
            else
                $k = $prefix_array[$k-1];

        }
        if ($str[$k] == $str[$i])
            ++$k;
        $prefix_array[$i] = $k;
    }
    return $prefix_array;
}

    public function find_strings_in_files_in_directory($path, $string_to_find)
    {

        $content = explode(";", $this ->get_directories($path));


        $result = array();

        foreach ($content as $item)
        {
            if (strpos($item,".txt") !== false)
                $result[$path . $item] = $this ->find_string_in_file($path . $item, $string_to_find);
            else if (strpos($item,".") === false && $item != "")
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
        try
        {
            $dirsarray = scandir($path);
        }
        catch (Exception $e)
        {
            return "Error";
        }

        $dirsstring = "";
        foreach ($dirsarray as $item)
        {
            $dirsstring .= $item.";";
        }

        return $dirsstring;
    }
}
?>