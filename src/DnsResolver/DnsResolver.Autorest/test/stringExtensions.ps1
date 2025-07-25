function ExtractArmResourceName([String]$ResourceId){
    $arr = $ResourceId.Split("/");
    return $arr[$arr.Length - 1]
}