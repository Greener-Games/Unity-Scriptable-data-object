# Scriptable Data Asset for Unity

This repository provides a powerful and easy-to-use system for managing global data in Unity projects through a "Scriptable Data Asset". It's a lightweight, yet robust solution for creating singleton `ScriptableObject`s.

## What is a Scriptable Data Asset?

A Scriptable Data Asset, in the context of this repository, is a `ScriptableObject` that is automatically instantiated and can be accessed from anywhere in your code base with a single static reference. Think of it as a centralized data container for your game's settings, configurations, or any other data that needs to be globally accessible.

This utility provides a generic base class, `ScriptableDataAsset<T>`, that you can inherit from to create your own custom data assets. The system ensures that there is only one instance of your data asset, and it handles its creation and loading, so you don't have to.

## Why use it?

Managing game data, especially settings that need to be accessed by various systems, can be challenging. This Scriptable Data Asset pattern offers several advantages:

*   **Centralized Data:** It provides a single source of truth for your data, making it easier to manage and modify.
*   **Easy Access:** Data can be accessed from any script, at any time, without needing a direct reference to an object in a scene.
*   **Decoupling:** It helps to decouple your systems. Instead of scripts communicating directly with each other, they can refer to the data asset, reducing dependencies.
*   **Persistence:** The data is stored as an asset in your project, which means it persists between play sessions in the editor and is included in your build.
*   **Automatic Instantiation:** The asset is created automatically if it doesn't exist, simplifying the setup process.

This tool is ideal for managing things like:
*   Game settings (e.g., audio volume, difficulty)
*   Player progression data
*   Theme and UI color palettes
*   Game balancing values
*   References to prefabs or other assets

In essence, the Scriptable Data Asset is a clean, efficient, and Unity-friendly way to handle shared data in your projects.
