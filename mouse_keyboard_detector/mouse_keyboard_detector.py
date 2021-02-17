import tkinter
import time
import win32api 
import keyboard

def button_3(event): #右鍵
    exit()
def refresh():
    global key,mouse,txt
    if win32api.GetKeyState(0x01)<0:
        canvas.delete(mouse)
        mouse = canvas.create_image(300,100, image=filename_mouse_press)
    else:
        canvas.delete(mouse)
        mouse = canvas.create_image(300,100, image=filename_mouse)   
    key_name = ["up arrow","down arrow","left arrow","right arrow","backspace","escape"] 
    show_name = ["Up","Down","Left","Right","BS","Esc"]
    is_pressed = 0
    for num,k in enumerate(key_name):
        if keyboard.is_pressed(k):
            is_pressed = 1
            canvas.delete(key)
            key = canvas.create_image(100,100, image=filename_key_press)
            canvas.delete(txt) 
            txt = canvas.create_text(100,100, font=("microsoft yahei", 32), text=show_name[num], fill='black')
    if is_pressed == 0:
        canvas.delete(key)
        key = canvas.create_image(100,100, image=filename_key)
        pass
    root.after(100, refresh)
      
root = tkinter.Tk()
root.overrideredirect(True)      #懸浮
root.wm_attributes('-topmost',1) #沒有右上角
root.attributes("-alpha", 0.7)   #視窗透明度 0~1
root.geometry("400x200+0+480")

canvas = tkinter.Canvas(root)
canvas.configure(width = 400,height = 200)
filename_key = tkinter.PhotoImage(file = "pic/key.png")
filename_key_press = tkinter.PhotoImage(file = "pic/key_press.png")
filename_mouse = tkinter.PhotoImage(file = "pic/mouse.png")
filename_mouse_press = tkinter.PhotoImage(file = "pic/mouse_press.png")
key = canvas.create_image(100,100, image=filename_key)
mouse = canvas.create_image(300,100, image=filename_mouse)
txt = canvas.create_text(100,100, font=("microsoft yahei", 32), text='', fill='black') 
canvas.bind("<Button-3>",button_3)
canvas.pack()
refresh() 

root.mainloop()