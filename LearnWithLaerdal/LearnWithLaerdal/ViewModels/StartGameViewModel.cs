using MvvmHelpers.Commands;
using Plugin.BLE;
using Plugin.BLE.Abstractions.Contracts;
using Plugin.BLE.Abstractions.Exceptions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
using Command = Xamarin.Forms.Command;

namespace LearnWithLaerdal.ViewModels
{
    public class StartGameViewModel : ViewModelBase
    {
        public UriImageSource Image { get; set; } =
            new UriImageSource
            {
                Uri = new Uri("https://images.wsdot.wa.gov/sw/005vc00032.jpg"),
                CachingEnabled = true,
                CacheValidity = TimeSpan.FromMinutes(1)
            };

        public Command RefreshCommand { get; }

        public StartGameViewModel()
        {
            RefreshCommand = new Command(() =>
            {
                Image = new UriImageSource
                {
                    Uri = new Uri("https://images.wsdot.wa.gov/sw/005vc00032.jpg"),
                    CachingEnabled = true,
                    CacheValidity = TimeSpan.FromMinutes(1)
                };


                OnPropertyChanged(nameof(Image));
            });

            RefreshLongCommand = new AsyncCommand(async () =>
            {

                // TODO: ADD connection 
               await bleStuff();
            });

        }

        public async Task bleStuff() {

            var ble = CrossBluetoothLE.Current;
            var adapter = CrossBluetoothLE.Current.Adapter;
            List<IDevice> deviceList = new List<IDevice>();
            var state = ble.State;
            ble.StateChanged += (s, e) =>
            {
                Console.WriteLine($"The bluetooth state changed to {e.NewState}");
            };


            IDevice device;


            adapter.DeviceDiscovered += (s, a) =>
            {
                Console.WriteLine(a.Device.Name);
                deviceList.Add(a.Device);
                
            };

            try
            {
                await adapter.StartScanningForDevicesAsync();

                for (int i = 0; i < deviceList.Count; i++)
                {
                    if (deviceList[i].Name.Contains("33"))
                    {
                        device = deviceList[i];
                        try
                        {
                           await adapter.ConnectToDeviceAsync(device);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                    }
                }
            }
            catch (Exception e) { Console.WriteLine(e.Message); }
        }

        public AsyncCommand RefreshLongCommand { get; }

    }
}

