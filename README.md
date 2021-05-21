# XwDiskSpace

A simple disk space investigator  
No bells, no whistles  

So, where is the difference to other softwares that also do this?  

The necessity came once i had to check the space on huge storages with hundreds of millions on files.  
Existing tools try to keep in memory a complete space representation, all subfolders, all files.  
This consumes all RAM available, and i never was able to check the storages.  
  
This tool counts all the space in a subfolder, all files, but only keeps one level in memory.  
Once you identify which subfolder uses more space, you can then check that one.

Sure, it will have to check the storage multiple times but at least it can be done with very little memory.

![Connection Manager](Images/Main.jpg)

## In case you are feeling generous  
[![PayPal donate button](https://www.paypalobjects.com/webstatic/en_US/btn/btn_donate_pp_142x27.png)](https://www.paypal.me/maxsnts)