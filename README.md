# ![unity](https://img.shields.io/badge/Unity-100000?style=for-the-badge&logo=unity&logoColor=white)  Tiny Builder

<img alt="logo" src="https://www.objectionary.com/cactus.svg" height="50px" />  

[![EO principles respected here](https://www.elegantobjects.org/badge.svg)](https://www.elegantobjects.org)
[![We recommend IntelliJ Rider](https://www.elegantobjects.org/intellij-idea.svg)](https://www.jetbrains.com/rider/)

[![License](https://img.shields.io/badge/license-MIT-green.svg)](https://github.com/LLarean/unity-tiny-builder/blob/main/LICENSE)
[![CodeFactor](https://www.codefactor.io/repository/github/llarean/unity-tiny-builder/badge)](https://www.codefactor.io/repository/github/llarean/unity-tiny-builder)
[![Maintenance](https://img.shields.io/badge/Maintained%3F-yes-green.svg)](https://github.com/llarean/unity-tiny-builder/graphs/commit-activity)
[![Releases](https://img.shields.io/github/v/release/llarean/unity-tiny-builder)](https://github.com/llarean/unity-tiny-builder/releases)
![stability-unstable](https://img.shields.io/badge/stability-unstable-red.svg)

## About

Unity Tiny Builder is a build automation utility designed to streamline the Android build process for Unity projects. This tool helps developers automate repetitive build tasks while maintaining clean, maintainable code. Developed with respect for [Elegant Objects](https://www.elegantobjects.org/)

> **Note**: Currently in development and supports Android builds only. iOS support is being considered for future releases.

## Features

- **Smart File Naming**: Automatically generates build files with the format `ProjectName_[version]` (e.g., `ProjectName_1.0.1`) following [semantic versioning](https://semver.org/)
- **Flexible Naming Options**: Add custom prefixes and postfixes to build file names
- **Multiple Build Types**: Support for both APK and AAB formats - build separately or together
- **Version Management**: Automatically increment build/patch numbers
- **Configuration Management**: Create and manage configuration files for consistent builds

## Installation

Choose one of the following installation methods:

### Method 1: Unity Package (Recommended)
1. Download the latest [TinyBuilder.unitypackage](https://github.com/llarean/unity-tiny-builder/releases) from releases
2. In Unity, go to **Assets → Import Package → Custom Package**
3. Select the downloaded `.unitypackage` file

### Method 2: Manual Installation
1. Clone or [download](https://github.com/llarean/unity-tiny-builder/archive/master.zip) this repository
2. Copy the files to your Unity project's `Assets` folder

### Method 3: Package Manager (Git URL)
1. Open Unity Package Manager (**Window → Package Manager**)
2. Click the **+** button and select **Add package from git URL**
3. Enter: `https://github.com/llarean/unity-tiny-builder.git`

### Method 4: Package Manager (Manifest)
Add the following line to your `Packages/manifest.json`:
```json
"com.llarean.unity-tiny-builder": "https://github.com/llarean/unity-tiny-builder.git"
```

## Requirements

- Unity 2019.4 or higher
- Android SDK configured for Unity
- Git (for Package Manager installation methods)

## Usage

1. Open the Tiny Builder window: **Tools → Tiny Builder**
2. Configure your build settings:
   - Set project name prefix/postfix (optional)
   - Choose build type (APK, AAB, or both)
   - Configure version increment options
3. Click **Build** to start the automated build process

## 🗺Roadmap

- [ ] **Technical Improvements**: Performance optimizations and code enhancements
- [ ] **Refactoring**: Code structure improvements following EO principles
- [ ] **Testing**: Comprehensive unit and integration tests
- [ ] **Repository Design**: Better project structure and documentation
- [ ] **Production Ready**: Stability improvements for commercial use
- [ ] **iOS Support**: Cross-platform build automation (under consideration)
- [ ] **Asset Store**: Publishing to Unity Asset Store

## Contributing

We welcome contributions! Please feel free to:
- Report bugs and issues
- Suggest new features
- Submit pull requests
- Improve documentation

Before contributing, please read our coding guidelines based on [Elegant Objects](https://www.elegantobjects.org/) principles.

## License

This project is licensed under the MIT License - see the [LICENSE.md]([LICENSE.md](https://github.com/LLarean/unity-tiny-builder?tab=MIT-1-ov-file)) file for details.

## Acknowledgments

- Built with [Elegant Objects](https://www.elegantobjects.org/) principles in mind
- Recommended IDE: [JetBrains Rider](https://www.jetbrains.com/rider/)


---

<div align="center">
  <strong>Made with ❤️ for the Unity community</strong>
  <br><br>
  ⭐ If this project helped you, please consider giving it a star!
</div>
