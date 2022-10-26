docker run -d \
    --name project_ztb_postgres \
    -p 5432:5432 \
    -e POSTGRES_USER=admin \
    -e POSTGRES_PASSWORD=admin1234 \
    -v postgres_data_ztb:/var/lib/postgresql/data \
    postgres
