<?php
include("Logic.php");
$l = new Logic();

if (isset($_POST["getDirs"]) && preg_match("/(\\\\?([^\\/]*[\\/])*)([^\\/]+)$/", $_POST["getDirs"]) && strpos($_POST["getDirs"], ".") === false)
{
    try
    {
        $l -> get_directories($_POST["getDirs"]);
    }
    catch (Exception $e)
    {
        echo "";
    }
}
else
    echo "";

?>