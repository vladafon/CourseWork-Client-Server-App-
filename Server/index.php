<?php
//include("Logic.php");

//$l = new Logic();

//$a = $l->find_strings_in_files_in_directory("/test/","abc");

//echo "";
?>
<h2> Форма для регистрации студентов</h2>
<form action="findString.php" method=POST>
   
    Path
    <input type=text name="path"
        path />
    String
    <input type=text name="string" />
    <input type="submit" value="Send" />
</form>