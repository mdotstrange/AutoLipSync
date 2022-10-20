# Simple auto lip sync script for Unity

![alt text](https://media.giphy.com/media/cilORnhbi89xYPT2zK/source.gif)

**Made using AutoLipSync**
* https://store.steampowered.com/app/1355310/Nightmare_Puppeteer/
* https://www.youtube.com/watch?v=Phx0fdT96DU&feature=youtu.be



A simple Unity C# script that will drive a **lower** jaw based on audio amplitude from an audio clip. It uses a low pass filter to smooth the output.
A custom SLATE action is included called "PlayAudioWithLipSync" use it in Slate to drive the jaw in your cutscenes.

**AutojawSync script**
![alt text](https://i.imgur.com/IHqKOtn.png)

*Set the audio source and adjust the sensitivity and min/max to your liking

**Slate action**
![alt text](https://i.imgur.com/wwKUoYp.png)

*When using the Slate action, Slate will populate the Audiosource variable so you can leave it empty. Don't forget to drag/drop the AutoJawSync script into the field at the bottom of the Slate action.

**SLATE cutscene editor is much nicer than Timeline imo as a professional animation filmmaker**

**Speechblend action**
![alt text](https://i.imgur.com/QWGC7Xc.png)

Speechblend is a Unity asset that does basic lip sync with visemes- it works nicely with Daz Models

**NOTES**

-The "Live jaw rotation output" variable is just for debugging purposes, it is the output of the jaw rotation so changing it won't do anything
-This script works best with audio files that have been compressed and don't have any background noise, so use gate + compression on your audio files for best results.
-Package includes working example head model from above gif(Includes texture hence the large file size)
