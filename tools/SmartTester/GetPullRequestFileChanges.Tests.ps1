#end to end testing based on repository: https://github.com/NelsonDaniel/test

$here = Split-Path -Parent $MyInvocation.MyCommand.Path
$sut = (Split-Path -Leaf $MyInvocation.MyCommand.Path) -replace '\.Tests\.', '.'
. "$here\$sut"


$testCases = @(
    @{ 
    jsonResult=@{StatusCode=200; StatusDescription="OK";`
                 Content='[{"sha":1,"commit":{"info":"mock_info"}}]'};
    listResult=@("mock_info");
    listCount = 1
     },
    @{
    jsonResult=@{StatusCode=200; StatusDescription="OK";`
                 Content='[{"sha":1,"commit":{"info":"mock_info_1"}},
                           {"sha":2,"commit":{"info":"mock_info_2"}}]'} 
    listResult= @("mock_info_1","mock_info_2");
    listCount = 2    
    }
)

Describe "Get-CommitsList" {
    Context "[mock] When there is one commit: " {

        Mock Invoke-WebRequest {return $testCases[0].jsonResult}
       
        It "Returns a list with one object, and that object has a property called commit, 
            and that commit has the same information as the json string obtained from
            the API." {
            $result = Get-CommitsList -RepositoryOwner owner -RepositoryName name -PullRequestNumber 42

            $result[0].commit.info | Should be $testCases[0].listResult
            $result.Count | Should be $testCases[0].listCount
        }       
    }
    Context "[mock] When there is multiple commits: " {

        Mock Invoke-WebRequest {return $testCases[1].jsonResult}     
        
        It "Returns a list with multiple objects, and those objects have a property called commit, 
            and that commit has the same information as the json string obtained from
            the API." {
            $result = Get-CommitsList -RepositoryOwner owner -RepositoryName name -PullRequestNumber 42

            $result.commit.info | Should be $testCases[1].listResult          
            $result.Count | Should be $testCases[1].listCount
        }    
    }
    
    Context "[live test] When there is one commit: " {
                    
        It "Returns a list with one object, and that object has a property called commit, 
            and that commit has the same information as the json string obtained from
            the API." {
            $result = Get-CommitsList -RepositoryOwner NelsonDaniel `
                                      -RepositoryName test `
                                      -PullRequestNumber 1

            $result.Count | Should be 1
            $result.sha | Should be @("3441384fcbf3a2bb1ef2375bed5708b987eb7b12")
        }       
    }
    
    Context "[live test] When there is multiple commits: " {
                    
        It "Returns a list with multiple objects, and those objects have a property called commit, 
            and that commit has the same information as the json string obtained from
            the API." {
            $result = Get-CommitsList -RepositoryOwner NelsonDaniel `
                                      -RepositoryName test `
                                      -PullRequestNumber 2

            $result.Count | Should be 3 #for this pull request three commits were made
            $result.sha | Should be @("e4214af67b9ccdadf42c71824d4db4bbea2fc446",
                                        "96ea8de3d78d581d5d54f2deaed489b9697c80ed",
                                        "d55d755edceac146273e1b9a4923074df5fd96d6")
                                        
        }       
    }
    
}


$testCases = @(
#test case 0
    @{ 
    commitList = @(@{sha=1});
    jsonResult=@{StatusCode=200; StatusDescription="OK";`
                 Content='{"sha":1,"files":[{"filename":"file1.txt"}]}'};
    listResult= @("file1.txt")
    listCount = 1
     },
#test case 1
    @{
    commitList = @(@{sha=1});
    jsonResult=@{StatusCode=200; StatusDescription="OK";`
                                 Content='{"sha":1,"files":[{"filename":"file1.txt"},  
                                                            {"filename":"file2.txt"}]}'}
    listResult=@("file1.txt", "file2.txt")
    listCount = 2 
    },
#test case 2
    @{
    commitList = @(@{sha=1}, @{sha=2});
    jsonResultList=@(@{StatusCode=200; StatusDescription="OK";`
                                 Content='{"sha":1,"files":[{"filename":"file1.txt"},  
                                                            {"filename":"file2.txt"}]}'},
                    @{StatusCode=200; StatusDescription="OK";`
                       Content='{"sha":2,"files":[{"filename":"file1.txt"},  
                                                  {"filename":"file3.txt"}]}'}
                    )
    listResult=@("file1.txt", "file2.txt", "file3.txt")
    listCount = 3
    },
#test case 3
    @{
    commitList = @(@{sha=1}, @{sha=2});
    jsonResultList=@(@{StatusCode=200; StatusDescription="OK";`
                                 Content='{"sha":1,"files":[{"filename":"file1.txt"},  
                                                            {"filename":"file2.txt"}]}'},
                    @{StatusCode=200; StatusDescription="OK";`
                       Content='{"sha":2,"files":[{"filename":"file1.txt"},  
                                                  {"filename":"file3.txt"}]}'}
                    )
    listResult=@("file1.txt", "file2.txt","file3.txt")
    listCount = 3
    },
#test case 4
    @{
    commitList = @(@{sha=1}, @{sha=2});
    jsonResultList=@(@{StatusCode=200; StatusDescription="OK";`
                                 Content='{"sha":1,"files":[{"filename":"file1.txt"},  
                                                            {"filename":"file2.txt"},
                                                            {"filename":"file3.txt"}]}'},
                    @{StatusCode=200; StatusDescription="OK";`
                                 Content='{"sha":2,"files":[{"filename":"file2.txt"},  
                                                            {"filename":"file3.txt"},
                                                            {"filename":"file4.txt"}]}'}
                    )
    listResult=@("file1.txt", "file2.txt", "file3.txt", "file4.txt")
    listCount = 4
    }
    
)

$errorMessage =  "One or multiple parameters are incorrect."                  
                    

Describe "Get-FilesChangedFromCommits" {
    Context "[mock] When there is one commit and one file change: " {

        Mock Invoke-WebRequest {return $testCases[0].jsonResult }       
        
      
        It "Returns one url, and that url is the same that was returned from the json string
            obtained from the API."{

            $result = Get-FilesChangedFromCommits -RepositoryOwner owner -RepositoryName name -Commits $testCases[0].commitList

            $result.Count | Should be $testCases[0].listCount
            $result | Should be $testCases[0].listResult
        
        }    
    }

    Context "[mock] When there is one commit and multiple file changes: " {

        Mock Invoke-WebRequest {return $testCases[1].jsonResult  }

        It "Returns multiple urls, and those urls are the same that were returned from the json string
            obtained from the API."{

            $result = Get-FilesChangedFromCommits -RepositoryOwner owner -RepositoryName name  -Commits $testCases[1].commitList

            $result.Count | Should be $testCases[1].listCount
            $result | Should be $testCases[1].listResult
        
        }    
    }
    
    Context "[mock] When there is multiple commits and multiple file changes, 
             but the files modified are different: " {
      
        Mock Invoke-WebRequest { 
            $parsedUri = ([string]$Uri).split('/')
            $sha = $parsedUri[$parsedUri.Count - 1] 
            switch($sha){
                1 {return $testCases[2].jsonResultList[0]}
                2 {return $testCases[2].jsonResultList[1]}
            }            
        }

        It "Returns multiple urls, and those urls are the same that were returned from the json string
            obtained from the API."{
            $result = Get-FilesChangedFromCommits -RepositoryOwner owner -RepositoryName name  -Commits $testCases[1].commitList           
            
            $result.Count | Should be $testCases[1].listCount
            $result | Should be $testCases[1].listResult            
        }    
    }

    Context "[mock] When there is multiple commits and multiple file changes,
             but one file was modified in multiple commits: " {
      
        Mock Invoke-WebRequest { 
            $parsedUri = ([string]$Uri).split('/')
            $sha = $parsedUri[$parsedUri.Count - 1] 
            switch($sha){
                1 {return $testCases[3].jsonResultList[0]}
                2 {return $testCases[3].jsonResultList[1]}
            }            
        }

        It "Returns multiple urls. However for the file that was changed in multiple
            commits, just one url is returned. "{
            $result = Get-FilesChangedFromCommits -RepositoryOwner owner -RepositoryName name  -Commits $testCases[2].commitList           
            
            $result.Count | Should be $testCases[3].listCount
            $result | Should be $testCases[3].listResult               
        }    
    }

    Context "[mock] When there is multiple commits and multiple file changes,
             but some files are modified in multiple commits: " {
      
        Mock Invoke-WebRequest { 
            $parsedUri = ([string]$Uri).split('/')
            $sha = $parsedUri[$parsedUri.Count - 1] 
            switch($sha){
                1 {return $testCases[4].jsonResultList[0]}
                2 {return $testCases[4].jsonResultList[1]}
            }            
        }

        It "Returns multiple urls. However for the files that were modified in multiple
            commits, just one url per file modified is returned. "{
            $result = Get-FilesChangedFromCommits -RepositoryOwner owner -RepositoryName name  -Commits $testCases[4].commitList           
            
            $result.Count | Should be $testCases[4].listCount
            $result | Should be $testCases[4].listResult               
        }    
    }  

    Describe "Get-PullRequestFileChanges" {
    
        Context "[live test]When there is one commit and one file change: " {

            It "Returns one path, that path is from the file changed." {

            $result = Get-PullRequestFileChanges -RepositoryOwner NelsonDaniel `
                                                 -RepositoryName test `
                                                 -PullRequestNumber 3 

            $result | Should be @("file1.txt")                
            }
        }
        
        Context "[live test]When there is one commit and multiple file changes: " {

            It "Returns multiple paths, and those paths are from the file changed." {

            $result = Get-PullRequestFileChanges -RepositoryOwner NelsonDaniel `
                                                 -RepositoryName test `
                                                 -PullRequestNumber 4 

            $result | Should be @("file1.txt","file2.txt","file3.txt")
            }
        }
        Context "[live test] When there is multiple commits and multiple file changes,
             and some files are modified in multiple commits: " {
      

            It "Returns multiple urls. However for the files that were modified in multiple
                commits, just one url per file modified is returned. "{
                $result = Get-PullRequestFileChanges -RepositoryOwner NelsonDaniel `
                                                     -RepositoryName test `
                                                     -PullRequestNumber 5 

                $result | Should be @("file1.txt","file2.txt","file3.txt", "file4.txt")                        
            }
        } 
                
        
        Context "[live test] When the user enters an invalid parameter: " {      

            It "Throws an error." {
                {Get-PullRequestFileChanges -RepositoryOwner random `
                                           -RepositoryName random `
                                            -PullRequestNumber 5 }`
                                            | Should Throw $errorMessage                                     
            }     
        }  

    }  
        
}