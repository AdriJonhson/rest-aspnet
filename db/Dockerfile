FROM mysql:5.7.22
EXPOSE 3306
COPY ./RestWithAspNET/db/migrations/ /home/database/
COPY ./RestWithAspNET/db/dataset/ /home/database/
COPY ./RestWithAspNET/ci/init_database.sh/ /docker-entrypoint-initdb.d/init_database.sh