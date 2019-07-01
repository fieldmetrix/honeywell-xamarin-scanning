#define HONEYWELLSCANNER
using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Widget;
using Honeywell.AIDC.CrossPlatform;
using System;
using System.Collections.Generic;

namespace XamarinScanner
{

	[Activity(Label = "SecondActivity")]
	public class SecondActivity : AppCompatActivity
	{

		public static TextView scanData = null;
		Button btnClearScan = null;
		Button btnScan = null;

#if HONEYWELLSCANNER
		private BarcodeReader mSelectedReader { get; set; }
		public string scannedData { get; set; }
		private bool mSoftOneShotScanStarted = false;
#endif

		protected override void OnCreate(Bundle savedInstanceState)
		{

			base.OnCreate(savedInstanceState);

			// Create your application here
			SetContentView(Resource.Layout.activity_second);

			//editBarcodeData = FindViewById<EditText>(Resource.Id.EditBarcodeData);
			scanData = FindViewById<TextView>(Resource.Id.scanDataView);

			btnClearScan = FindViewById<Button>(Resource.Id.BtnClearScan);
			btnClearScan.Click += BtnClearScan_Click;

			btnScan = FindViewById<Button>(Resource.Id.BtnScan);
			btnScan.Click += BtnScan_Click;

		}

		protected override void OnStart()
		{
			base.OnStart();
		}

		/// <summary>
		/// When the ScanPage is about to go to the background, release the scanner.
		/// </summary>
		protected override void OnPause()
		{

			base.OnPause();

#if HONEYWELLSCANNER
			CloseBarcodeScanner();
#endif

		}

		/// <summary>
		/// When the ScanPage is about to go to the foreground, claim the scanner.
		/// </summary>
		protected override void OnResume()
		{

			base.OnResume();

#if HONEYWELLSCANNER
			OpenBarcodeReader();

			//lock the orientationt to Portrait
			this.RequestedOrientation = Android.Content.PM.ScreenOrientation.Portrait;
#endif

		}

		protected override void OnStop()
		{
			base.OnStop();
		}

		public override void OnBackPressed()
		{
#if HONEYWELLSCANNER
			mSelectedReader = null;
#endif
		Finish();
		}

		private void BtnClearScan_Click(object sender, EventArgs e)
		{
			scanData.Text = "";
		}

		private async void BtnScan_Click(object sender, EventArgs e)
		{
#if HONEYWELLSCANNER
			if (mSelectedReader != null && mSelectedReader.IsReaderOpened)
			{
				BarcodeReader.Result result = await mSelectedReader.SoftwareTriggerAsync(true);
				if (result.Code == BarcodeReader.Result.Codes.SUCCESS)
				{
					// Set mSoftOneShotScanStarted to true if not in continuous scan mode.
					// The mSoftOneShotScanStarted flag is used to turn off the software
					// trigger after a barcode is read successfully.
					mSoftOneShotScanStarted = true;
				}
				else
				{
					ScannerCode.DisplayAlert("Error", "Failed to turn on software trigger, Code:" + result.Code +
						" Message:" + result.Message, Application.Context);
				}
			}
#endif
		}

#if HONEYWELLSCANNER

		#region Honeywell Scanning via Xamarin SDK

		private async void MBarcodeReader_BarcodeDataReady(object sender, BarcodeDataArgs e)
		{

			this.RunOnUiThread(() =>
			{//Changed Invoke UI Thread
				if (!string.IsNullOrEmpty(e.Data))
					UpdateDetailItemWithScannedValue(e.Data);
			});

			if (mSoftOneShotScanStarted)
			{
				// Turn off the software trigger.
				await mSelectedReader.SoftwareTriggerAsync(false);
				mSoftOneShotScanStarted = false;
			}

		}

		/// <summary>
		/// Opens the selected scanner device.
		/// </summary>
		public void OpenBarcodeReader()
		{

			mSelectedReader = new BarcodeReader(ScannerCode.SelectedScannerName, Application.Context);

			if (mSelectedReader != null)
			{
				mSelectedReader.BarcodeDataReady += MBarcodeReader_BarcodeDataReady;
			}

			ScannerCode.OpenBarcodeReader(mSelectedReader);

		}

		/// <summary>
		/// Closes the selected scanner device.
		/// </summary>
		public void CloseBarcodeScanner()
		{

			if (mSelectedReader != null)
			{
				mSelectedReader.BarcodeDataReady -= MBarcodeReader_BarcodeDataReady;
			}

			ScannerCode.CloseBarcodeScanner(mSelectedReader, mSoftOneShotScanStarted);

		}

		#endregion

#endif

		private static void UpdateDetailItemWithScannedValue(string contents)
		{
			string barcodeData = scanData.Text;
			barcodeData = $"{barcodeData}{System.Environment.NewLine}{contents}";
			scanData.SetText(barcodeData, TextView.BufferType.Normal);
		}

	}

}