

"""
    Plugin for Launching SlingFront
"""


import sys
import os
import fnmatch
import xbmc
import xbmcgui
import xbmcplugin

import time
import re
import urllib
import subprocess_hack
import xml.dom.minidom
import socket
import exceptions

import random
from traceback import print_exc

import shutil



from xbmcaddon import Addon






class Main:
    
    slingfront = {}



    def __init__( self ):
        
        if ( xbmc.Player().isPlaying() ):
	    xbmc.executebuiltin('PlayerControl(Play)')
        xbmc.sleep(400)            
        
        
        
        # store an handle pointer
        self._handle = int(sys.argv[ 1 ])

        self._path = sys.argv[ 0 ]
       

        PLUGIN_DATA_PATH = xbmc.translatePath( os.path.join( "special://home/addons", "plugin.program.slingfront") )
        info = subprocess_hack.STARTUPINFO()
        info.dwFlags = 1
        info.wShowWindow = 0
        ap = PLUGIN_DATA_PATH + "\\launch.bat"
        arguments = ""
        apppath = PLUGIN_DATA_PATH
        startproc = subprocess_hack.Popen(r'%s %s' % (ap, arguments), cwd=apppath, startupinfo=info)
   


 
        startproc.wait()
        xbmc.sleep(200)


        ap = xbmc.translatePath("special://xbmc") + "\\xbmc.exe"
        arguments = ""
        apppath = xbmc.translatePath("special://xbmc")
        startproc = subprocess_hack.Popen(r'%s %s' % (ap, arguments), cwd=apppath, startupinfo=info)
 
        # startproc.wait()
        xbmc.sleep(200)
        xbmc.executebuiltin('PlayerControl(Play)') 
	xbmc.sleep(400)  
        
        

 


