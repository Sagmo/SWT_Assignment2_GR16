close all; clear all; clc

y1 = 5000;
x1 = 5000;

y_tmp2 = 7000;
x_tmp2 = 7000;


dY = y_tmp2 - y1;
dX = x_tmp2 - x1;

dx2 = sqrt( (5000^2) - (dY^2) );
dy2 = sqrt( (5000^2) - (dX^2) );

x2 = dx2 + x1
y2 = dy2 + y1

close all; clear all; clc


x1 = 6000;
x2 = 63628;

y1 = 5800;
y2 = 32187;

dX = x2 - x1;
dY = y2 - y1;

ang = atan2(dY, dX)
ang_deg = ang * 180/pi