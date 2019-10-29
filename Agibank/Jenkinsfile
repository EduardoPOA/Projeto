pipeline {
    stages {

        stage('test') {
            steps {
                script { 
                    sh 'docker-compose build'
                }
            }
        }

        stage('exec') {
            steps {
                script {
                    sh 'docker-compose up -d'
                }
            }
        }

    }
}