﻿using Microsoft.UI.Xaml;
using NickvisionTubeConverter.Shared.Controllers;
using NickvisionTubeConverter.Shared.Models;
using NickvisionTubeConverter.WinUI.Views;
using System;

namespace NickvisionTubeConverter.WinUI;


/// <summary>
/// The App
/// </summary>
public partial class App : Application
{
    public static Window? MainWindow { get; private set; } = null;
    private readonly MainWindowController _mainWindowController;

    /// <summary>
    /// Constructs an App
    /// </summary>
    public App()
    {
        InitializeComponent();
        _mainWindowController = new MainWindowController();
        //AppInfo
        _mainWindowController.AppInfo.ID = "org.nickvision.tubeconverter";
        _mainWindowController.AppInfo.Name = "Nickvision Tube Converter";
        _mainWindowController.AppInfo.ShortName = _mainWindowController.Localizer["ShortName"];
        _mainWindowController.AppInfo.Description = $"{_mainWindowController.Localizer["Description"]}.";
        _mainWindowController.AppInfo.Version = "2023.5.0-beta1";
        _mainWindowController.AppInfo.Changelog = "- Redesigned UI\n- Added the ability to stop all downloads\n- Added the ability to retry all failed downloads\n- Added the ability to clear queued downloads\n- Fixed an issue where some downloads could not be stopped and retried\n- Updated translations (Thanks everyone on Weblate!)";
        _mainWindowController.AppInfo.GitHubRepo = new Uri("https://github.com/NickvisionApps/TubeConverter");
        _mainWindowController.AppInfo.IssueTracker = new Uri("https://github.com/NickvisionApps/TubeConverter/issues/new");
        _mainWindowController.AppInfo.SupportUrl = new Uri("https://github.com/NickvisionApps/TubeConverter/discussions");
        //Theme
        if (_mainWindowController.Theme == Theme.Light)
        {
            RequestedTheme = ApplicationTheme.Light;
        }
        else if (_mainWindowController.Theme == Theme.Dark)
        {
            RequestedTheme = ApplicationTheme.Dark;
        }
    }

    /// <summary>
    /// Occurs when the app is launched
    /// </summary>
    /// <param name="args">LaunchActivatedEventArgs</param>
    protected override void OnLaunched(LaunchActivatedEventArgs args)
    {
        //Main Window
        MainWindow = new MainWindow(_mainWindowController);
        MainWindow.Activate();
    }
}
