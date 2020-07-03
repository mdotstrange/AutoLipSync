# Simple auto lip sync script for Unity

![alt text](https://media.giphy.com/media/cilORnhbi89xYPT2zK/source.gif)


A simple Unity C# script that will drive a **lower** jaw based on audio amplitude from an audio clip. It uses a low pass filter to smooth the output.
A custom SLATE action is included called "PlayAudioWithLipSync" use it in Slate to drive the jaw in your cutscenes.

**AutojawSync script**
![alt text](https://i.imgur.com/IHqKOtn.png)

*Set the audio source and adjust the sensitivity and min/max to your liking

**Slate action**
![alt text](https://i.imgur.com/wwKUoYp.png)

*When using the Slate action, Slate will populate the Audiosource variable so you can leave it empty. Don't forget to drag/drop the AutoJawSync script into the field at the bottom of the Slate action.

**SLATE cutscene editor is much nicer than Timeline imo as a professional animation filmmaker**
