#!/bin/bash
FILE1=$1
echo 'generando' $FILE1

hix generate Models.cs $FILE1
mv output/Models/$FILE1.cs output/$FILE1.cs

hix generate Create.cs $FILE1
mv output/Create/$FILE1.cs output/$FILE1.Create.cs

hix generate Update.cs $FILE1
mv output/Update/$FILE1.cs output/$FILE1.Update.cs

hix generate Table.cs $FILE1
mv output/Table/$FILE1.cs output/$FILE1.Table.cs