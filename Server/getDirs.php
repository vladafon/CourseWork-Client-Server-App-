<?php
include("Logic.php");
$l = new Logic();

if (isset($_POST["directory"]) && preg_match("/^(\/){1}(([^\/]+)(\/{1}))*$/", $_POST["directory"]))
{
    try
    {
        echo $l -> get_directories($_POST["directory"]);
    }
    catch (Exception $e)
    {
        echo "500 Internal Server Error";
        http_response_code(500);
    }
}
else
{
    echo "400 Bad Request";
    http_response_code(400);
}


?>