﻿var rotateSpeed = 25.0;
var speed = 50.0;
 
function Update() {
var transAmount = speed * Time.deltaTime;
var rotateAmount = rotateSpeed * Time.deltaTime;
 
if (Input.GetKey("up")) {
transform.Rotate(rotateAmount, 0, 0);	

}
if (Input.GetKey("down")) {
transform.Rotate(-rotateAmount, 0, 0);	
}
if (Input.GetKey("a")) {
transform.Rotate(0, -rotateAmount, 0);
}

if (Input.GetKey("left")) {
transform.Rotate(0, -rotateAmount, 0);
}

if (Input.GetKey("d")) {
transform.Rotate(0, rotateAmount, 0);
}

if (Input.GetKey("right")) {
transform.Rotate(0, rotateAmount, 0);
}

/*if (Input.GetKey ("z")) {
transform.Rotate(0, 0, rotateAmount);
}
        
if (Input.GetKey ("x")) {
transform.Rotate(0, 0, -rotateAmount);
}*/

if (Input.GetKey ("w")) {
transform.Translate(0, 0, (transAmount * (-1)));
}
        
if (Input.GetKey ("s")) {
transform.Translate(0, 0, (transAmount * 1 ));
}

}