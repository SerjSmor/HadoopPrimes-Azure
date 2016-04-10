$clusterName = "http://localhost:50111"

$mrMapper = "WordCountMapper.exe"
$mrReducer = "WordCountReducer.exe"
$mrMapperFile = "/WordCount/Apps/WordCountMapper.exe"
$mrReducerFile = "/WordCount/Apps/WordCountReducer.exe"
$mrInput = "/WordCount/Input/"
$mrOutput = "/WordCount/Output"
$mrStatusOutput = "/WordCount/MRStatusOutput"

$mrJobDef = New-AzureHDInsightStreamingMapReduceJobDefinition -JobName mrWordCountStreamingJob -StatusFolder $mrStatusOutput -Mapper $mrMapper -Reducer $mrReducer -InputPath $mrInput -OutputPath $mrOutput


$mrJobDef.Files.Add($mrMapperFile)
$mrJobDef.Files.Add($mrReducerFile)

$creds = Get-Credential -Message "Enter password" -UserName "hadoop"

#$userName = "hadoop"
#$securePassword = "serj"
#$creds = New-Object System.Management.Automation.PSCredential($userName, $securePassword)



$mrJob = Start-AzureHDInsightJob -Cluster $clusterName -Credential $creds -JobDefinition $mrJobDef
Wait-AzureHDInsightJob -Credential $creds -job $mrJob -WaitTimeoutInSeconds 3600

