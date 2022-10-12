#include "mainwindowcontroller.hpp"
#include <filesystem>

using namespace NickvisionTubeConverter::Controllers;
using namespace NickvisionTubeConverter::Models;

MainWindowController::MainWindowController(AppInfo& appInfo, Configuration& configuration) : m_appInfo{ appInfo }, m_configuration{ configuration }, m_isOpened{ false }, m_isDevVersion{ m_appInfo.getVersion().find("-") != std::string::npos }
{

}

const AppInfo& MainWindowController::getAppInfo() const
{
    return m_appInfo;
}

bool MainWindowController::getIsDevVersion() const
{
    return m_isDevVersion;
}

AddDownloadDialogController MainWindowController::createAddDownloadDialogController() const
{
    return { m_configuration };
}

PreferencesDialogController MainWindowController::createPreferencesDialogController() const
{
    return { m_configuration };
}

void MainWindowController::registerSendToastCallback(const std::function<void(const std::string& message)>& callback)
{
    m_sendToastCallback = callback;
}

void MainWindowController::startup()
{
    if(!m_isOpened)
    {
        m_isOpened = true;
    }
}
