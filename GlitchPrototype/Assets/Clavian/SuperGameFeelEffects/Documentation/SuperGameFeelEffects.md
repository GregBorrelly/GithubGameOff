<pre>
<head>
	<title>Super Game Feel Effects Documentation</title>
	<link rel="shortcut icon" type="image/png" href="/SGFEDocImages/favicon.png"/>
</head>
<style>
* {
	box-sizing:border-box;
}
body {
    background-color: #a2baff; 
    background-image: url("SGFEDocImages/background.png");
    background-repeat: no-repeat;
    background-position: center top;
    background-attachment: fixed;
    background-size: cover;
    font-family: "Trebuchet MS", Helvetica, sans-serif;
    color: #000;
    padding:0 15px;
}
a {
    color: #000;
    font-weight: bold;
}
pre {
    font-family: "courier new", courier, monospace;
    font-size: 14px;
    font-weight: bold;
}
code {
    font-family: "courier new", courier, monospace;
    font-size: 14px;
    font-weight: bold;
}
.column{
    background-color: #ff7930;
    width: 100%;
	max-width:1200px;
    margin:30px auto;
    padding: 15px;
}
.banner {
    text-align: center;
    max-width: 100%;
    color: #000;
}
.banner img {
    max-width: 100%;
}
.tableofcontents {
    background-color: #FFF;
    max-width: 50%;
    padding: 15px;
    margin: 15px;
}
.textarea {
    margin: 50px 50px;
}
.rightbox {
    color: #000;
    text-align: center;
    font-style: italic;
    float: right;
    background-color: #FFF;
    padding: 15px;
    margin: 0px 0px 0px 15px;
    max-width: 33%;
}
.rightbox img {
    width: 100%;
}
h1 {
    font-weight: bold;
    font-size: 32px;
    text-decoration: underline;
}
h2 {
    font-weight: bold;
    font-size: 28px;
    text-decoration: underline;
}
h3 {
    font-weight: bold;
    font-size: 20px;
    text-decoration: underline;
}
h4 {
    font-weight: bold;
    font-size: 16px;
    text-decoration: underline;
}
hr {
    border-top: 2px solid #000;
    border-bottom: 2px solid #000;
    border-left: 2px solid #000;
    border-right: 2px solid #000;
}

/* Mobiley Styley */

@media only screen and (max-width: 1000px) { 

	.tableofcontents {
		max-width:100%;
	}
	
}

@media only screen and (max-width: 640px) { 

	.textarea {
		margin:15px;
		word-break:break-word;
	}
	.rightbox {
		float:none;
		max-width:100%;
		margin:0 0 15px;
		padding:5px;
	}
	ul{
		padding-left:0;
		list-style-type:none;
	}
	ol {
		padding-left:15px;
	}
	ul ul, ol ul {
		padding-left:20px;
		list-style-type:disc;
	}
	
}
</style></pre>
<br>
<br>
<br>
<article class="column"><article class="banner">
<img src="SGFEDocImages/banner.png"/><br>
<br>
Super Game Feel Effects Documentation - v1.0
</article><article class="tableofcontents"><article class="textarea">
#Table of Contents

[Features](#Features)

1. [Adding Super Game Feel Effects to Unity](#Adding Super Game Feel Effects to Unity)
	* [Importing Super Game Feel Effects into Unity](#Importing Super Game Feel Effects into Unity)
	* [Adding Super Game Feel Effects to a Scene](#Adding Super Game Feel Effects to a Scene)
2. [Getting Started](#Getting Started)
	* [Tips & Tricks](#Tips & Tricks)
3. [Functions & Variables](#Functions & Variables)
	* [Screenshake](#Screenshake)
	* [Kickback](#Kickback)
	* [Hitstop](#Hitstop)

[Notes](#Notes)
[ChangeLog](#ChangeLog)
[Credits](#Credits)
</article></article><article class="textarea">

***

<a name="Features"></a>
#Features
* Super Game Feel Effects is a Unity tool that allows you to add game feel effects like Screenshake, Kickback, and Hitstop to a game without conflict.
* All effects work with other scripts. Screenshake and Kickback do not interfere with any other camera scripts.
* Extentions allow all functions to be called through a camera.

***

<a name="Adding Super Game Feel Effects to Unity"></a>
#1. Adding Super Game Feel Effects to Unity
<a name="Importing Super Game Feel Effects into Unity"></a>
##a. Importing Super Game Feel Effects into Unity 

To import Super Game Feel Effects into your project, either drag in the .unitypackage file, or get it from the asset store window.

###Imported folders, what they do, and if you need to import them or not, alphabetically:

* __"Documentation"__ contains these docs! You don't need to import them, but you probably should!
* __"Example"__ contains the demo scene. Not needed if you don't want the demo.

"ConstantShake.cs" is a bonus script for making an object shake constantly.
"SuperGameFeelEffectsExtentions.cs" allows the rest of the scripts to be called as a camera extention.
The rest of the scripts are the actual Screenshake, Kickback, and Hitstop effects.

<a name="Adding Super Game Feel Effects to a Scene"></a>
##b. Adding Super Game Feel Effects to a Scene

To add any Super Game Feel Effects script to a camera, select "Add Component" in the inspector of an existing camera. They can be found under "Utility > Super Game Feel Effects".

***

<a name="Getting Started"></a>
#2. Getting Started
<a name="Tips & Tricks"></a>
##a. Tips & Tricks

* Screenshake, Kickback, and Hitstop can all be called through the camera they're attached to! So instead of calling "Camera.main.GetComponent<Screenshake>().Shake()", you can just call "Camera.main.Shake()".

* If you want to 'store' multiple types of screenshakes on the same camera, you can call specific scripts directly.

<article class="rightbox">
<a href="SGFEDocImages/inspector1.png"><img src="SGFEDocImages/inspector1.png"/></a><br><br>
The inspector window.
</article>

***

<a name="Functions & Variables"></a>
#3. Functions & Variables

<a name="Screenshake"></a>
##a. Screenshake

* ###void Screenshake.Shake()

* ###void Camera.Shake()
	Tells the camera to shake, with the current preferences.

* ###void Screenshake.Shake(float multiplier)

* ###void Camera.Shake(float multiplier)
	Tells the camera to shake, with the current preferences, with a multiplier on the intensity.

* ###AnimationCurve Screenshake.curve
	The intensity of the screenshake over time.

* ###Vector3 Screenshake.strength
	The strength of the screenshake effect based on the curve, split into axises.

* ###bool Screenshake.useLocalSpace
	Whether or not Screenshake.strength is relative to the direction the camera is facing, or world rotation. This will most likely want to be set to true.

* ###float Screenshake.intensity
	A multipier of strength.

* ###float Screenshake.time
	How long the shake effect lasts.

* ###[RANGE 0 - 7] int Screenshake.roundDecimals
	Whether or not the screenshake effect will be rounded to a specific decimal place or not. Not rounded if left at 7.

<a name="Kickback"></a>
##b. Kickback

* ###void Kickback.Kick(Vector3 normalizedDirection)

* ###void Camera.Kick(Vector3 normalizedDirection)
	Tells the camera to kickback with a specified vector, multiplied by strength.

* ###void Kickback.Kick(Vector3 normalizedDirection, float multiplier)

* ###void Camera.Kick(Vector3 normalizedDirection, float multiplier)
	Tells the camera to shake, with the current preferences, with a multiplier on the intensity.

* ###AnimationCurve Kickback.curve
	The intensity of the kickback over time.

* ###bool Kickback.useLocalSpace
	Whether or not the kickback's normalizedDirection is relative to the direction the camera is facing, or not.

* ###float Kickback.intensity
	How much the camera will kick back.

* ###float Kickback.time
	How long the kickback lasts.

* ###[RANGE 0 - 7] int Kickback.roundDecimals
	Whether or not the kickback will be rounded to a specific decimal place or not. Not rounded if left at 7.

<a name="Hitstop"></a>
##c. Hitstop

* ###void Hitstop.Stop()

* ###void Camera.Stop()
	Sets the game's timescale to follow the curve for the specified amount of time.

* ###void Hitstop.Stop(float multiplier)

* ###void Camera.Stop(float multiplier)
	Sets the game's timescale to follow the curve for the specified amount of time, with time multipied by the multiplier.

* ###float Hitstop.time
	The amount of time the effect will last for.

* ###AnimationCurve Hitstop.curve
	The value the effect will be, over time. By default this is a horizontal line at a 0 value.

***

<a name="Notes"></a>
#Notes
* If a function is called through a camera, and the camera does not yet have the component, it will automatically be added to the camera and called. The default strength/intensity for each component is set to 1, so the multiplier can be useful when using this method.
* "ConstantShake.cs" is a bonus script that can be attached to an object.

##Known Bugs
* None at the moment!

##Planned Features / To Do List:
* Nothing at the moment!

***

<a name="ChangeLog"></a>
#ChangeLog
###v1.0
* Initial release!

***

<a name="Credits"></a>
#Credits
Coding and design by Kai Clavier ([@KaiClavier](http://twitter.com/KaiClavier))  
Extra CSS help by Tak ([@takorii](http://twitter.com/takorii))  
<br>
<br>
</article>
</article>