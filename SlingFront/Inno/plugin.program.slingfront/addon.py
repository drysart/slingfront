"""
    Plugin for Launching SlingFront
"""


import sys
import os

# plugin constants
__plugin__ = "SlingFront"
__author__ = "Tom Speirs"

__version__ = "1"

if ( __name__ == "__main__" ):
    import resources.lib.slingfront_plugin as plugin
    plugin.Main()

