using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Honeywell.AIDC.CrossPlatform;

namespace XamarinScanner
{
    /// <summary>
    /// 
    /// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /// 
    /// This appliction was created to provide an example for implementing Data Collection with the Xamarin.Android template.
    /// There has been no attempt to make this a complete application. In that sense you can change the symbology settings 
    /// and they will be active while the application is running but they are not saved when the application is closed.
    /// 
    /// The code contained in this application is there to aid you in development. It may not be the only way or the best way to 
    /// accomplish the task but is intended to provide guidance in the creation of your own application.
    /// 
    /// ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /// 
    /// THE LICENSE AGREEMENT FOR THIS SOFTWARE CAN BE FOUND IN THE SOLUTIONS ITEMS FOLDER OF THIS APPLICATION
    /// 
    /// ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /// </summary>
    class  ScannerCode 
    {

        public const string DEFAULT_READER_KEY = "default";
        public static Dictionary<string, object> settings = new Dictionary<string, object>();
        private static AlertDialog.Builder alert = null;
		public static System.Collections.Generic.IList<string> ScanList = null;
		public static string SelectedScannerName { get; set; }

        /// <summary>
        /// Writes all to the symbology setting keys to a dictionary
        /// </summary>
        private static void CreateSymbologyDictionary()
        {
            //if (mSelectedReader != null && settings.Count == 0)
            //{
            //    settings.Add(mSelectedReader.SettingKeys.AztecEnabled, false);
            //    settings.Add(mSelectedReader.SettingKeys.AztecMaximumLength, 1550); //max = 3832
            //    settings.Add(mSelectedReader.SettingKeys.AztecMininumLength, 1); // min = 1
            //    settings.Add(mSelectedReader.SettingKeys.CenterDecodeEnabled, false);
            //    settings.Add(mSelectedReader.SettingKeys.ChinaPostEnabled, false);
            //    settings.Add(mSelectedReader.SettingKeys.ChinaPostMaximumLength, 80); // max = 80
            //    settings.Add(mSelectedReader.SettingKeys.ChinaPostMinimumLength, 4); // min = 4
            //    settings.Add(mSelectedReader.SettingKeys.CodabarCheckDigitMode, mSelectedReader.SettingValues.CodabarCheckDigitMode_NoCheck);
            //    settings.Add(mSelectedReader.SettingKeys.CodabarConcatEnabled, false);
            //    settings.Add(mSelectedReader.SettingKeys.CodabarEnabled, false);
            //    settings.Add(mSelectedReader.SettingKeys.CodabarMaximumLength, 48); // max = 48
            //    settings.Add(mSelectedReader.SettingKeys.CodabarMinimumLength, 2); // min = 0
            //    settings.Add(mSelectedReader.SettingKeys.CodabarStartStopTransmitEnabled, false);
            //    settings.Add(mSelectedReader.SettingKeys.CodablockFEnabled, false);
            //    settings.Add(mSelectedReader.SettingKeys.CodablockFMaximumLength, 2048); // max=2048
            //    settings.Add(mSelectedReader.SettingKeys.CodablockFMinimumLength, 0); //min = 0
            //    settings.Add(mSelectedReader.SettingKeys.Code11CheckDigitMode, mSelectedReader.SettingValues.Code11CheckDigitMode_DoubleDigitCheck);
            //    settings.Add(mSelectedReader.SettingKeys.Code11Enabled, false);
            //    settings.Add(mSelectedReader.SettingKeys.Code11MaximumLength, 48); // max=48
            //    settings.Add(mSelectedReader.SettingKeys.Code11MinimumLength, 0); //min=0
            //    settings.Add(mSelectedReader.SettingKeys.Code128Enabled, true);
            //    settings.Add(mSelectedReader.SettingKeys.Code128MaximumLength, 80); // max=80
            //    settings.Add(mSelectedReader.SettingKeys.Code128MinimumLength, 0); //min=0
            //    settings.Add(mSelectedReader.SettingKeys.Code39Base32Enabled, false);
            //    settings.Add(mSelectedReader.SettingKeys.Code39CheckDigitMode, mSelectedReader.SettingValues.Code39CheckDigitMode_NoCheck);
            //    settings.Add(mSelectedReader.SettingKeys.Code39Enabled, false);
            //    settings.Add(mSelectedReader.SettingKeys.Code39FullAsciiEnabled, false);
            //    settings.Add(mSelectedReader.SettingKeys.Code39MaximumLength, 48); //max=48
            //    settings.Add(mSelectedReader.SettingKeys.Code39MinimumLength, 1); //min=1
            //    settings.Add(mSelectedReader.SettingKeys.Code39StartStopTransmitEnabled, false);
            //    settings.Add(mSelectedReader.SettingKeys.Code93Enabled, false);
            //    settings.Add(mSelectedReader.SettingKeys.Code93MaximumLength, 80); //max=80
            //    settings.Add(mSelectedReader.SettingKeys.Code93MinimumLength, 0); //min=0
            //    settings.Add(mSelectedReader.SettingKeys.CombineComposites, false);
            //    settings.Add(mSelectedReader.SettingKeys.CompositeEnabled, false);
            //    settings.Add(mSelectedReader.SettingKeys.CompositeMaximumLength, 300); // max=300
            //    settings.Add(mSelectedReader.SettingKeys.CompositeMinimumLength, 1); // min=1
            //    settings.Add(mSelectedReader.SettingKeys.CompositeWithUpcEnabled, false);
            //    settings.Add(mSelectedReader.SettingKeys.DatamatrixEnabled, true);
            //    settings.Add(mSelectedReader.SettingKeys.DatamatrixMaximumLength, 1550); //max=3166
            //    settings.Add(mSelectedReader.SettingKeys.DatamatrixMinimumLength, 1); // min=1
            //    settings.Add(mSelectedReader.SettingKeys.DecodeWindowBottom, 100); // 50 = center of image window, 100 = bottom
            //    settings.Add(mSelectedReader.SettingKeys.DecodeWindowLeft, 0); // 50 = center of image window, 0 = left edge
            //    settings.Add(mSelectedReader.SettingKeys.DecodeWindowRight, 100); // 50 = center of image window, 100 = right edge
            //    settings.Add(mSelectedReader.SettingKeys.DecodeWindowTop, 0); // 50 = center of image window, 0 = top
            //    settings.Add(mSelectedReader.SettingKeys.Ean13AddendaRequiredEnabled, false);
            //    settings.Add(mSelectedReader.SettingKeys.Ean13AddendaSeparatorEnabled, false);
            //    settings.Add(mSelectedReader.SettingKeys.Ean13CheckDigitTransmitEnabled, true);
            //    settings.Add(mSelectedReader.SettingKeys.Ean13Enabled, true);
            //    settings.Add(mSelectedReader.SettingKeys.Ean13FiveCharAddendaEnabled, false);
            //    settings.Add(mSelectedReader.SettingKeys.Ean13TwoCharAddendaEnabled, false);
            //    settings.Add(mSelectedReader.SettingKeys.Ean8AddendaRequiredEnabled, false);
            //    settings.Add(mSelectedReader.SettingKeys.Ean8AddendaSeparatorEnabled, false);
            //    settings.Add(mSelectedReader.SettingKeys.Ean8CheckDigitTransmitEnabled, true);
            //    settings.Add(mSelectedReader.SettingKeys.Ean8Enabled, false);
            //    settings.Add(mSelectedReader.SettingKeys.Ean8FiveCharAddendaEnabled, false);
            //    settings.Add(mSelectedReader.SettingKeys.Ean8TwoCharAddendaEnabled, false);
            //    settings.Add(mSelectedReader.SettingKeys.EanUccEmulationMode, mSelectedReader.SettingValues.EanUccEmulationMode_Gs1CodeExpansionOff);
            //    settings.Add(mSelectedReader.SettingKeys.Gs1128Enabled, true);
            //    settings.Add(mSelectedReader.SettingKeys.Gs1128MaximumLength, 80); //max=80
            //    settings.Add(mSelectedReader.SettingKeys.Gs1128MinimumLength, 0); //min=0
            //    settings.Add(mSelectedReader.SettingKeys.HanXinEnabled, false);
            //    settings.Add(mSelectedReader.SettingKeys.HanXinMaximumLength, 6000); //max = 6000
            //    settings.Add(mSelectedReader.SettingKeys.HanXinMinimumLength, 0); //min=0
            //    settings.Add(mSelectedReader.SettingKeys.Iata25Enabled, false);
            //    settings.Add(mSelectedReader.SettingKeys.Iata25MaximumLength, 80); //min=80
            //    settings.Add(mSelectedReader.SettingKeys.Iata25MinimumLength, 4); //min=4
            //    settings.Add(mSelectedReader.SettingKeys.Interleaved25CheckDigitMode, mSelectedReader.SettingValues.Interleaved25CheckDigitMode_NoCheck);
            //    settings.Add(mSelectedReader.SettingKeys.Interleaved25Enabled, false);
            //    settings.Add(mSelectedReader.SettingKeys.Interleaved25MaximumLength, 48); //max=48
            //    settings.Add(mSelectedReader.SettingKeys.Interleaved25MinimumLength, 0); //min=0
            //    settings.Add(mSelectedReader.SettingKeys.Isbt128Enabled, false);
            //    settings.Add(mSelectedReader.SettingKeys.KoreanPostEnabled, false);
            //    settings.Add(mSelectedReader.SettingKeys.KoreanPostMaximumLength, 48); //max=48
            //    settings.Add(mSelectedReader.SettingKeys.KoreanPostMinimumLength, 4); //min=4
            //    settings.Add(mSelectedReader.SettingKeys.LinearDamageImprovements, false);
            //    settings.Add(mSelectedReader.SettingKeys.Matrix25Enabled, false);
            //    settings.Add(mSelectedReader.SettingKeys.Matrix25MaximumLength, 80); // max=80
            //    settings.Add(mSelectedReader.SettingKeys.Matrix25MinimumLength, 4); //min=4
            //    settings.Add(mSelectedReader.SettingKeys.MaxicodeEnabled, false);
            //    settings.Add(mSelectedReader.SettingKeys.MaxicodeMaximumLength, 150); // max=150
            //    settings.Add(mSelectedReader.SettingKeys.MaxicodeMinimumLength, 1); // min=1
            //    settings.Add(mSelectedReader.SettingKeys.MicroPdf417Enabled, false);
            //    settings.Add(mSelectedReader.SettingKeys.MicroPdf417MaximumLength, 2750); // max=2750
            //    settings.Add(mSelectedReader.SettingKeys.MicroPdf417MinimumLength, 1); // min=1
            //    settings.Add(mSelectedReader.SettingKeys.MsiCheckDigitMode, mSelectedReader.SettingValues.MsiCheckDigitMode_DoubleMod10Check);
            //    settings.Add(mSelectedReader.SettingKeys.MsiEnabled, false);
            //    settings.Add(mSelectedReader.SettingKeys.MsiMaximumLength, 48); // max=48
            //    settings.Add(mSelectedReader.SettingKeys.MsiMinimumLength, 2); //min=0
            //    settings.Add(mSelectedReader.SettingKeys.NotificationBadReadEnabled, true);
            //    settings.Add(mSelectedReader.SettingKeys.NotificationGoodReadEnabled, true);
            //    settings.Add(mSelectedReader.SettingKeys.NotificationVibrateEnabled, true);
            //    settings.Add(mSelectedReader.SettingKeys.Pdf417Enabled, true);
            //    settings.Add(mSelectedReader.SettingKeys.Pdf417MaximumLength, 2750); // max=2750
            //    settings.Add(mSelectedReader.SettingKeys.Pdf417MinimumLength, 1); // min=1
            //    settings.Add(mSelectedReader.SettingKeys.PlanetCheckDigitTransmitEnabled, false);
            //    settings.Add(mSelectedReader.SettingKeys.Postal2DMode, mSelectedReader.SettingValues.Postal2DMode_Usps);
            //    settings.Add(mSelectedReader.SettingKeys.PostnetCheckDigitTransmitEnabled, false);
            //    settings.Add(mSelectedReader.SettingKeys.QrCodeEnabled, true);
            //    settings.Add(mSelectedReader.SettingKeys.QrCodeMaximumLength, 3500); // max=7089
            //    settings.Add(mSelectedReader.SettingKeys.QrCodeMinimumLength, 1); // min=1
            //    settings.Add(mSelectedReader.SettingKeys.RssEnabled, false);
            //    settings.Add(mSelectedReader.SettingKeys.RssExpandedEnabled, false);
            //    settings.Add(mSelectedReader.SettingKeys.RssExpandedMaximumLength, 80); // max=80
            //    settings.Add(mSelectedReader.SettingKeys.RssExpandedMinimumLength, 1); // min=1
            //    settings.Add(mSelectedReader.SettingKeys.RssLimitedEnabled, false);
            //    settings.Add(mSelectedReader.SettingKeys.Standard25Enabled, false);
            //    settings.Add(mSelectedReader.SettingKeys.Standard25MaximumLength, 48); // max=48
            //    settings.Add(mSelectedReader.SettingKeys.Standard25MinimumLength, 4); // min=4
            //    settings.Add(mSelectedReader.SettingKeys.TelepenEnabled, false);
            //    settings.Add(mSelectedReader.SettingKeys.TelepenMaximumLength, 60); // max-60
            //    settings.Add(mSelectedReader.SettingKeys.TelepenMinimumLength, 1); // min=1
            //    settings.Add(mSelectedReader.SettingKeys.TelepenOldStyleEnabled, false);
            //    settings.Add(mSelectedReader.SettingKeys.Tlc39Enabled, false);
            //    settings.Add(mSelectedReader.SettingKeys.TriopticEnabled, false);
            //    settings.Add(mSelectedReader.SettingKeys.UpcAAddendaRequiredEnabled, false);
            //    settings.Add(mSelectedReader.SettingKeys.UpcAAddendaSeparatorEnabled, false);
            //    settings.Add(mSelectedReader.SettingKeys.UpcACheckDigitTransmitEnabled, true);
            //    settings.Add(mSelectedReader.SettingKeys.UpcACombineCouponCodeModeEnabled, false);
            //    settings.Add(mSelectedReader.SettingKeys.UpcACouponCodeModeEnabled, false);
            //    settings.Add(mSelectedReader.SettingKeys.UpcAEnable, true);
            //    settings.Add(mSelectedReader.SettingKeys.UpcAFiveCharAddendaEnabled, false);
            //    settings.Add(mSelectedReader.SettingKeys.UpcANumberSystemTransmitEnabled, false);
            //    settings.Add(mSelectedReader.SettingKeys.UpcATranslateEan13, false);
            //    settings.Add(mSelectedReader.SettingKeys.UpcATwoCharAddendaEnabled, false);
            //    settings.Add(mSelectedReader.SettingKeys.UpcE1Enabled, false);
            //    settings.Add(mSelectedReader.SettingKeys.UpcEAddendaRequiredEnabled, false);
            //    settings.Add(mSelectedReader.SettingKeys.UpcEAddendaSeparatorEnabled, false);
            //    settings.Add(mSelectedReader.SettingKeys.UpcECheckDigitTransmitEnabled, false);
            //    settings.Add(mSelectedReader.SettingKeys.UpcEEnabled, false);
            //    settings.Add(mSelectedReader.SettingKeys.UpcEExpandToUpcA, false);
            //    settings.Add(mSelectedReader.SettingKeys.UpcEFiveCharAddendaEnabled, false);
            //    settings.Add(mSelectedReader.SettingKeys.UpcENumberSystemTransmitEnabled, false);
            //    settings.Add(mSelectedReader.SettingKeys.UpcETwoCharAddendaEnabled, false);
            //    settings.Add(mSelectedReader.SettingKeys.VideoReverseEnabled, true);
            //}
        }

		/// <summary>
		/// gets all the scanner devices in the device list
		/// </summary>
		public static async void GetReaderList(Android.Content.Context context)
		{
			// get the available scanners            
			ScanList = await GetReaderNames(context);
			if (ScanList.Count > 0)
			{
				SelectedScannerName = ScanList[0].ToString();
			}
		}

		/// <summary>
		/// Gets the names of all connected barcode readers
		/// </summary>
		/// <returns></returns>
		public static async Task<List<string>> GetReaderNames(Android.Content.Context context)
        {
            IList<BarcodeReaderInfo> readerList = null;
            List<string> readerNames = new List<string>();
            try
            {               
                readerList = await BarcodeReader.GetConnectedBarcodeReaders(context);
                if (readerList.Count > 0)
                {
                    foreach (BarcodeReaderInfo reader in readerList)
                    {
                        readerNames.Add(reader.ScannerName);
                    }
                }
                else
                {
                    readerNames.Add(DEFAULT_READER_KEY);
                }
                
                return readerNames;

            }
            catch (Exception ex)
            {
                readerNames.Add(DEFAULT_READER_KEY);
                DisplayAlert("Error", "Failed to query connected readers, " + ex.Message, context);
                return readerNames;
            }
        }

		/// <summary>
		/// Opens the selected scanner device.
		/// </summary>
		public static async void OpenBarcodeReader(BarcodeReader barcodeReader)
		{

			if (!barcodeReader.IsReaderOpened)
			{

				BarcodeReader.Result result = await barcodeReader.OpenAsync();

				// Check to see is reader opened or is already open
				if (result.Code == BarcodeReader.Result.Codes.SUCCESS ||
					result.Code == BarcodeReader.Result.Codes.READER_ALREADY_OPENED)
				{

					SetScannerAndSymbologySettings(barcodeReader, Application.Context);

				}
				else
				{
					DisplayAlert("Error", "OpenAsync failed, Code:" + result.Code +
						" Message:" + result.Message, Application.Context);
				}

			}

		}

		/// <summary>
		/// Closes the selected scanner device.
		/// </summary>
		public static async void CloseBarcodeScanner(BarcodeReader barcodeReader, bool bSoftOneShotScanStarted)
		{

			if (barcodeReader != null && barcodeReader.IsReaderOpened)
			{

				if (bSoftOneShotScanStarted)
				{
					// Turn off the software trigger.
					await barcodeReader.SoftwareTriggerAsync(false);
					bSoftOneShotScanStarted = false;
				}

				BarcodeReader.Result result = await barcodeReader.CloseAsync();
				if (result.Code != BarcodeReader.Result.Codes.SUCCESS)
				{
					DisplayAlert("Error", "CloseAsync failed, Code:" + result.Code +
							" Message:" + result.Message, Application.Context);
				}

			}

			barcodeReader = null;

		}

		public static async void SetScannerAndSymbologySettings(BarcodeReader barcodeReader, Android.Content.Context context)
		{

			try
			{

				if (barcodeReader.IsReaderOpened)
				{
					Dictionary<string, object> settings = new Dictionary<string, object>()
					{
						{barcodeReader.SettingKeys.TriggerScanMode, barcodeReader.SettingValues.TriggerScanMode_OneShot },
						{barcodeReader.SettingKeys.Code128Enabled, true },
						{barcodeReader.SettingKeys.Code39Enabled, true },
						{barcodeReader.SettingKeys.Ean8Enabled, true },
						{barcodeReader.SettingKeys.Ean8CheckDigitTransmitEnabled, true },
						{barcodeReader.SettingKeys.Ean13Enabled, true },
						{barcodeReader.SettingKeys.Ean13CheckDigitTransmitEnabled, true },
						{barcodeReader.SettingKeys.Interleaved25Enabled, true },
						{barcodeReader.SettingKeys.Interleaved25MaximumLength, 100 },
						{barcodeReader.SettingKeys.Postal2DMode, barcodeReader.SettingValues.Postal2DMode_Usps }
					};

					BarcodeReader.Result result = await barcodeReader.SetAsync(settings);
					if (result.Code != BarcodeReader.Result.Codes.SUCCESS)
					{
						DisplayAlert("Error", "Symbology settings failed, Code:" + result.Code +
											" Message:" + result.Message, context);
					}
				}

			}
			catch (Exception exp)
			{
				DisplayAlert("Error", "Symbology settings failed. Message: " + exp.Message, context);
			}

		}

        /// <summary>
        /// Displays alert messages
        /// </summary>
        /// <param name="Title"></param>
        /// <param name="Msg"></param>
        public static void DisplayAlert(string Title, string Msg, Android.Content.Context context)
        {
            alert = new AlertDialog.Builder(context);
            alert.SetTitle(Title);
            alert.SetMessage(Msg);
            alert.SetPositiveButton("OK", (senderAlert, args) => { });
            Dialog dialog = alert.Create();
            dialog.Show();
        }

    }

}