import cv2
import time
import datetime
import numpy as np
import pymysql
import socket


e = None
f= None
start = 0.0
end = 0.0
tim = 0.0
ip = socket.gethostbyname(socket.gethostname())
strr = ''
time_it = None


def call_db(strr):
    print(strr[1]) 
    insert = "INSERT INTO tbldrowsiness(ip) values (%s)"  # SQL Query to insert ip and time into the database
    val =(strr)
    cursor.execute(insert, val) # execute the query
    conn.commit()
    print('updated to db')
    
def eye():
    global e,f,cap, start, end, tim, strr, data_db
    cap= cv2.VideoCapture(1)   # start recording video
    
    while(1):
        ret,frame = cap.read()
        #frame = cv2.resize(frame,(1440,900))
        gray = cv2.cvtColor(frame, cv2.COLOR_BGR2GRAY)   #convert into grayscale
        faces = face_cas.detectMultiScale(gray, 1.3, 5) # Detect face using haarcascade file

        for (x,y,w,h) in faces:
         #   global f
        #    global e

            fd = cv2.rectangle(frame, (x,y), (x+w, y+h), (255,255,255),3)  # Draw a rectangle around the detected face.
            roi_gray = gray[y:y+h, x:x+w]   #REGION OF INTEREST in gray scale
            roi_col = frame[y:y+h, x:x+w]   #REGION OF INTEREST in  BGR scale
            #print("value = ", fd)
            f = (faces.all == True)
            #print("checkimnh f ",f)
            # if isinstance(faces,np.ndarray):
            #     f = False
            #     print("face detected  ", f)
            eyes = eye_cas.detectMultiScale(roi_gray, 1.9,1) #Detect eyes
            for (ex,ey,ew,eh) in eyes:
                ed = cv2.rectangle(roi_col, (ex,ey), (ex+ew, ey+eh), (0,0,0), 3)# Draw a rectangle around the detected eyes.
                #print("eye = ", ed)
                e = (ed.all == False)
            if (f == False and e == True): # if face is detected and eyes are not found
                start = clock()   #current time
                
                #print("user is drowsy")
            elif(f == False and e == False):
                end = clock()
            else:
                pass
##                end = clock()    #current time
            tim = end - start  # take difference between end and start
            start = 0.0
            end = 0.0
            print(tim)
        
            if (tim >=10):  # If the difference is 10 seconds 
                strr = str(ip)#+','+sss[0:19]+'\n'   # IP address of the machine
                call_db(strr)
                print('1')
                    
            
            f = True          #rest face and eyes to NULL for next iteration
            e = True
            #end = 0.0
            #start = 0.0
           

        cv2.imshow('frame', frame)

        if cv2.waitKey(1) & 0xFF == ord('q'):
            break

if __name__ == '__main__':

    face_cas = cv2.CascadeClassifier(cv2.data.haarcascades + 'haarcascade_frontalface_default.xml') # haarcascade classfier for face
    eye_cas = cv2.CascadeClassifier(cv2.data.haarcascades+ 'haarcascade_eye.xml')                   # haarcascade classfier for eyes
    
    conn = pymysql.connect(host="148.72.232.170",user="usrDbdrowsiness",passwd="E03egd8$", database = "Dbdrowsiness") # SQL query to connect to DB
    cursor = conn.cursor()      #initialize cursor
    
    if (face_cas.empty() and eye_cas.empty()):  # Check if xml file is fault/corrupt
        print("fault in cascade files")
    else:
       eye()

    #print(data_db)
    cap.release()    # stop the video camera
    cv2.destroyAllWindows() # destroy the frames 
