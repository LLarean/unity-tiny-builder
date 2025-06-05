# ![unity](https://img.shields.io/badge/Unity-100000?style=for-the-badge&logo=unity&logoColor=white)  Tiny Builder

<img alt="logo" src="https://www.objectionary.com/cactus.svg" height="100px" />  

[![EO principles respected here](https://www.elegantobjects.org/badge.svg)](https://www.elegantobjects.org)
[![We recommend IntelliJ Rider](https://www.elegantobjects.org/intellij-idea.svg)](https://www.jetbrains.com/rider/)

[![License](https://img.shields.io/badge/license-MIT-green.svg)](https://github.com/LLarean/unity-tiny-builder/blob/master/LICENSE.md)
[![CodeFactor](https://www.codefactor.io/repository/github/llarean/unity-tiny-builder/badge)](https://www.codefactor.io/repository/github/llarean/unity-tiny-builder)
[![Maintenance](https://img.shields.io/badge/Maintained%3F-yes-green.svg)](https://GitHub.com/Naereen/StrapDown.js/graphs/commit-activity)
[![Releases](https://img.shields.io/github/v/release/llarean/unity-tiny-builder)](https://github.com/llarean/unity-tiny-builder/releases)
![stability-unstable](https://img.shields.io/badge/stability-unstable-red.svg)

A simple build automation utility (currently only for Android)

This repository is a practice of writing programs in the spirit of [Elegant Objects](https://www.elegantobjects.org/)

# FEATURES

- The build file name will be in the ProjectName_[version](https://semver.org/) format (`ProjectName_1.0.1`);
- The ability to add a prefix to the file name;
- The ability to add a postfix to the file name;
- The ability to assemble both APK and AAB separately, or together;
- Ability to automatically raise the build/patch number;
- Creating a configuration file;


# INSTALLATION

There are 4 ways to install this utility:

- import [TinyBuilder.unitypackage](https://github.com/llarean/unity-tiny-builder/releases) via *Assets-Import Package*
- clone/[download](https://github.com/llarean/unity-tiny-builder/archive/master.zip) this repository and move files to your Unity project's *Assets* folder
- (via Package Manager) Select Add package from git URL from the add menu. 
  - A text box and an Add button appear. Enter a valid Git URL in the text box:
  `https://github.com/llarean/unity-tiny-builder.git`
- (via Package Manager) add the following line to Packages/manifest.json:
  `"com.llarean.unity-tiny-builder": "https://github.com/llarean/unity-tiny-builder.git"`


# PLANS

- [ ] Technical improvements;
- [ ] Refactoring;
- [ ] Tests;
- [ ] Repository design;
- [ ] Using the package at work;
- [ ] Improvements for use with iOS (or not);
- [ ] Publishing in the [Asset Store](https://assetstore.unity.com/).
