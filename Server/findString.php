<?php
include("Logic.php");
$l = new Logic();

if (isset($_POST["string"]) && isset($_POST["path"]) && preg_match("/(\/){1}(([^\/]+)(\/{1}))*$/", $_POST["path"]))
{

    $result = $l ->find_strings_in_files_in_directory($_POST["path"],$_POST["string"]);
    if (count($result) == 0)
        echo "Sorry, but nothing was found";
    else
    {
         echo "Results of the search:<br>";
    foreach ($result as $key => $value)
    {
        if ($value != "")
        {
            echo "File \"".$key."\" contains searching string in lines: ".$value."<br>";
        }
    }
    }
   
}
else
{
    echo "400 Bad request";
}

?>