FROM node:8.5.0-alpine
EXPOSE 3000
COPY ./app.js /var/app/app.js
COPY ./package.json /var/app/package.json

RUN echo 'Installing NPM dependencies'
WORKDIR /var/app
RUN npm i

# Entrypoint
CMD ["node", "/var/app/app.js"]
