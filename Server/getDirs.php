<?php
include("Logic.php");
$l = new Logic();

if (isset($_POST["directory"]) && preg_match("/(\/){1}(([^\/]+)(\/{1}))*$/", $_POST["directory"]))
{
    try
    {
        echo $l -> get_directories($_POST["directory"]);
    }
    catch (Exception $e)
    {
        echo "Error";
    }
}
else
    echo "Error";

?>