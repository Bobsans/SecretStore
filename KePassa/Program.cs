﻿using DimTim.DependencyInjection;
using SecretStore.Core;
using SecretStore.Ui;
using SecretStore.Ui.Model;

namespace SecretStore;

public static class Program {
    [STAThread]
    public static void Main(string[] args) {
        App.Services = ConfigureServices();
        App.Services.Resolve<App>().Run();
    }

    private static IContainer ConfigureServices() {
        var builder = new ContainerBuilder();
        builder.Singleton<Logger>();
        builder.Singleton<SettingsManager>();
        builder.Singleton<RecordManager>();

        builder.Singleton<App>();
        builder.Scoped<MainWindow>();
        builder.Scoped<SettingsWindow>();
        builder.Scoped<SettingsGeneralPage>();
        builder.Scoped<SettingsStoragePage>();

        builder.Scoped<MainWindowViewModel>();
        builder.Scoped<SettingsWindowViewModel>();
        builder.Scoped<SettingsGeneralPageViewModel>();

        return builder.Build();
    }
}