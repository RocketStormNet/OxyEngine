from Oxy.Framework import *
from System import Math

##########################################
# Text printing with custom font example #
##########################################
def onLoad():
    global textObj
    global fpsCounter
    global timer
        
    timer = 0

    font = Resources.LoadFont("examples/assets/roboto.ttf", 48)
    font2 = Resources.LoadBitmapFont("examples/assets/font_example.png", " ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789")

    textObj = Graphics.NewText(font, "Hello World OxyEngine!")


def onUpdate(dt):
    global timer
    timer += dt

def onDraw():
    Graphics.Draw(fpsCounter, 10, 10)
    Graphics.Draw(textObj, 50, 150, Math.Sin(timer) * 10)

