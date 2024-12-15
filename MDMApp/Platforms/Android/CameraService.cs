using Android.Hardware.Camera2;
using Android.Content;

namespace MDMApp
{
    public class CameraService : ICameraService
    {
        public void EnableCamera()
        {
            var cameraManager = Android.App.Application.Context.GetSystemService(Context.CameraService) as CameraManager;
            if (cameraManager != null)
            {
                foreach (var id in cameraManager.GetCameraIdList())
                {
                    try
                    {
                        cameraManager.SetTorchMode(id, true);
                    }
                    catch
                    {
                        // Игнорируем ошибки (например, если камера не поддерживает вспышку)
                    }
                }
            }
        
        }

        public void DisableCamera()
        {
            var cameraManager = (CameraManager)Android.App.Application.Context.GetSystemService(Context.CameraService);
            foreach (var id in cameraManager.GetCameraIdList())
            {
                try
                {
                    cameraManager.SetTorchMode(id, false);
                }
                catch
                {
                    // Игнорируем ошибки
                }
            }
        }
    }
}