#!groovy
pipeline {
    agent any

    stages {
        stage('Code Checout') {
            steps {
                    checkout scm
            }
        }
        stage('Build') {
            steps {
                bat 'dotnet build'
            }
        }
        stage('Unit Test') {
            steps {
                bat 'dotnet test  /p:CollectCoverage=true /p:CoverletOutputFormat=opencover'
            }
        }
        stage('Sonar Qube') {
            steps {
                withSonarQubeEnv('sonarqube') {
                    bat "dotnet build-server shutdown"
                    bat """dotnet SonarScanner begin /k:ProductService /d:sonar.host.url=http://localhost:9000 /d:sonar.login="9785448551146f2decadd540edebba8b70d8af35" /d:sonar.cs.opencover.reportsPaths="ProductService.Test/coverage.opencover.xml" /d:sonar.coverage.exclusions="**Test*.cs"""
                    bat "dotnet build ProductService.sln"
                    bat """dotnet SonarScanner end /d:sonar.login="9785448551146f2decadd540edebba8b70d8af35"""
                }
            }
        }
        stage('Quality Gates') {
            steps {
                timeout(time: 5, unit: 'MINUTES') {
                    waitForQualityGate abortPipeline: true
                }
            }
        }
        stage('Publish') {
            steps {
                bat 'dotnet publish'
            }
        }
        stage('Deploy') {
            steps {
                echo 'Deployed'
            }
        }
    }

    post {
            always {
                echo 'Build Result:'
            }
            success {
                echo 'The .net build was successful !'
            }
            failure {
                echo 'The .net build failed !'
            }
        }
}
