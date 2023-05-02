FROM postgres:14.4-alpine3.16

COPY init.sql /docker-entrypoint-initdb.d/

ENV POSTGRES_USER postgres
ENV POSTGRES_PASSWORD P@ssw0rd
ENV POSTGRES_DB mealmate_db_dockerize

EXPOSE 5432

CMD ["postgres"]