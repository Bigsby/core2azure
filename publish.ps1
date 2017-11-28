dotnet publish
$currentDir = Get-Location
$source = "$currentDir\bin\Debug\netcoreapp2.0\publish"
$destination = "$currentDir\bin\publish.zip"
$subscriptionName = "Visual Studio Premium with MSDN"
$websitename = "bigsby-sp-core"

if (Test-Path $destination) {
    Remove-Item $destination
}

Add-Type -assembly "system.io.compression.filesystem"
[io.compression.zipfile]::CreateFromDirectory($source, $destination)

Login-AzureRmAccount

Get-AzureRmSubscription -SubscriptionName $subscriptionName | Select-AzureRmSubscription

Publish-AzureWebsiteProject -Package $destination -Name $websitename
Show-AzureWebsite -Name $websitename