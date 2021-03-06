properties {
	$nugetKey = ""
	
	$script = @{}
	$script.dir = (Split-Path -Parent $MyInvocation.ScriptName)
	
	$base = @{}
	$base.dir = (Split-Path -Parent $script.dir)
	$base.output = (Join-Path $base.dir "Dist")
	
	$source = @{}
	$source.dir = $base.dir
	$source.solution = @(Get-ChildItem $source.dir -Filter *.sln)[0].Name # "xxx.sln"

	$build = @{}
	$build.version = "3.0"
	if ($env:BUILD_NUMBER) { $build.version = "{0}.{1}" -f $build.version, $env:BUILD_NUMBER }
	if ($Env:BUILD_BUILDNUMBER) { $build.version = "{0}.{1}" -f $build.version, $Env:BUILD_BUILDNUMBER }
	$build.configuration = "Release"
	
	$nuget = @{}
	$nuget.dir = (Join-Path $base.dir ".nuget")
	$nuget.bin = (Join-Path $nuget.dir "nuget.exe")
	$nuget.nuspec_pack = @("")
	$nuget.pushsource = "https://nuget.org/"
	$nuget.sources = @("https://go.microsoft.com/fwlink/?LinkID=206669")
	$nuget.source = @($nuget.sources | ?{ $_ -ne "" -and $_ -ne $null }) -join ";"
	$nuget.output = $base.output
	$nuget.packages = (Join-Path $source.dir "packages")
	$nuget.version = "{0}" -f $build.version
	
	$xunit = @{}
	$xunit.dir = (Join-Path $base.dir (Join-Path "Librairies" "xunit-1.8"))
	$xunit.bin = (Join-Path $xunit.dir "xunit.console.clr4.x86.exe")
	$xunit.output = (Join-Path $base.dir "TestOut")
}
