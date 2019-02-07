@echo off
echo Deleting Server\obj ...
rmdir Server\obj /S /Q
echo Done
echo.
echo Deleting Scripts\obj ...
rmdir Scripts\obj /S /Q
echo Done
echo.
echo Deleting Ultima\obj ...
rmdir Ultima\obj /S /Q
echo Done
echo.
echo Scripts\Output ...
del Scripts\Output\* /Q
echo Done
echo.