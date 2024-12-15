//using Microsoft.Maui.Essentials;
using System.Text.Json.Serialization;

namespace MDMApp
{
    public partial class MainPage : ContentPage
    {

        private readonly ICameraService _cameraService;

        public MainPage()
        {
            InitializeComponent();
            _cameraService = DependencyService.Get<ICameraService>();
        }

        private void OnUpdateDeviceInfo(object sender, EventArgs e)
        {
            var deviceInfo = new
            {
                Model = DeviceInfo.Model,
                Manufacturer = DeviceInfo.Manufacturer,
                Name = DeviceInfo.Name,
                VersionString = DeviceInfo.VersionString,
                Platform = DeviceInfo.Platform.ToString(),
                Idiom = DeviceInfo.Idiom.ToString(),
                DeviceType = DeviceInfo.DeviceType.ToString()
            };

            DeviceInfoLabel.Text =
                $"Модель: {deviceInfo.Model}\n" +
                $"Производитель: {deviceInfo.Manufacturer}\n" +
                $"Имя: {deviceInfo.Name}\n" +
                $"Версия ОС: {deviceInfo.VersionString}\n" +
                $"Платформа: {deviceInfo.Platform}\n" +
                $"Тип устройства: {deviceInfo.DeviceType}";
        }

        private async void OnGetLocation(object sender, EventArgs e)
        {
            try
            {
                var location = await Geolocation.GetLastKnownLocationAsync();

                if (location != null)
                {
                    LocationLabel.Text = $"Широта: {location.Latitude}, Долгота: {location.Longitude}";
                }
                else
                {
                    LocationLabel.Text = "Местоположение недоступно.";
                }
            }
            catch (Exception ex)
            {
                LocationLabel.Text = $"Ошибка: {ex.Message}";
            }
        }

        private void OnEnableCamera(object sender, EventArgs e)
        {
            _cameraService.EnableCamera();
        }

        private void OnDisableCamera(object sender, EventArgs e)
        {
            _cameraService.DisableCamera();
        }
    }
}
