<?php
include("Logic.php");
$l = new Logic();

if (isset($_POST["string"]) && isset($_POST["path"]) && preg_match("/(\/){1}(([^\/]+)(\/{1}))*$/", $_POST["path"]))
{
    echo "Results of the search:<br>";
    $result = $l ->find_strings_in_files_in_directory($_POST["path"],$_POST["string"]);

    foreach ($result as $key => $value)
    {
        if ($value != "")
        {
            echo "File \"".$key."\" contains searching string in lines: ".$value."<br>";
        }
    }
}
else
{
    echo "Wrong path/string";
}

?>