# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [Unreleased]

## [1.6.0] - 2021-10-07

### Added

- Added `BaseHelpCommand` to show command help

### Changed

- BaseStartup is now part of namespace `Zen.Host`
- Json configuration is no longer added by default.

### Removed

- Removed dependency on Autofac
- Removed dependency of Microsoft.Extensions.Configuration.Json
- Removed `ConfigureContainer` function from BaseStartup

## [1.5.0] - 2021-09-27

### Added 

- Added configuration addition from command line

## [1.4.0] - 2021-07-16

### Added 

- Added configuration addition from command line

## [1.3.1] - 2021-07-16

### Updated

- Updated dependencies

## [1.3.0] - 2021-06-28

### Updated

- Updated dependencies

## [1.2.0] - 2021-06-12

### Updated

- Updated package metadata

## [1.1.0] - 2021-06-09

### Updated

- Updated ConfigureServices and ConfigureContainer function to include app configuration

## [1.0.2] - 2021-06-09

### Fixed

- Fixed autofac registration

## [1.0.1] - 2021-06-09

### Changed

- Made appsettings.json optional

## [1.0.0] - 2021-06-09

### Added

- Added Startup class for configuring DI
- Added extension function for Autofac to add all commands from assembly to DI
- Added Base Command containing execute and validate functions 

[Unreleased]: https://github.com/WajahatAliAbid/zen-clifx-extensions/compare/1.6.0...HEAD
[1.6.0]: https://github.com/WajahatAliAbid/zen-clifx-extensions/compare/1.5.0...1.6.0
[1.5.0]: https://github.com/WajahatAliAbid/zen-clifx-extensions/compare/1.4.0...1.5.0
[1.4.0]: https://github.com/WajahatAliAbid/zen-clifx-extensions/compare/1.3.1...1.4.0
[1.3.1]: https://github.com/WajahatAliAbid/zen-clifx-extensions/compare/1.3.0...1.3.1
[1.3.0]: https://github.com/WajahatAliAbid/zen-clifx-extensions/compare/1.2.0...1.3.0
[1.2.0]: https://github.com/WajahatAliAbid/zen-clifx-extensions/compare/1.1.0...1.2.0
[1.1.0]: https://github.com/WajahatAliAbid/zen-clifx-extensions/compare/1.0.2...1.1.0
[1.0.2]: https://github.com/WajahatAliAbid/zen-clifx-extensions/compare/1.0.1...1.0.2
[1.0.1]: https://github.com/WajahatAliAbid/zen-clifx-extensions/compare/1.0.0...1.0.1
[1.0.0]: https://github.com/WajahatAliAbid/zen-clifx-extensions/releases/tag/1.0.0