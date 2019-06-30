# honeywell-xamarin-scanning
Using Honeywell Xamarin Scanning SDK for one shot scanning

The Honeywell Xamarin samples code uses static event handlers.

This works well enough for a single activity, however extending the sample code to work with multiple activities 
rapidly resulted in issues for us. We experienced "double scans" when activities were opened and closed repeatedly. 
The reason behind this was static event handlers that were not being unsubscribed in the sample code.

In the Opening and Closing the Scanner section of the Honeywell Xamarin Scanning SDK documents they advise:
"Because the scanner is shared among applications, it is a good practice to open the scanner only when it is needed
and close it when your application becomes inactive. The common practice on the Android platform is to open the 
scanner when the scanning activity is about to be displayed, and close the scanner when the scanning activity is 
about to be hidden."

This is difficult to achieve with their existing sample code so we have adapted the Honeywell sample code to 
demonstrate how we use the Honeywell Xamarin Scanning SDK for multiple activities.

All rights and licensing belong to Honeywell.
