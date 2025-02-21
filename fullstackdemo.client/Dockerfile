# Use Node.js as the base image for building the Angular app
FROM node:20 AS build
WORKDIR /app

# Copy only package.json and package-lock.json for better caching
COPY fullstackdemo.client/package.json fullstackdemo.client/package-lock.json ./
RUN npm install

# Copy the rest of the Angular project files
COPY fullstackdemo.client/ ./

# Build the Angular app
RUN npm run build --prod

# Use Nginx as the final container for serving the Angular app
FROM nginx:latest
COPY --from=build /app/dist/fullstackdemo.client /usr/share/nginx/html

# Expose port 80
EXPOSE 80

# Start Nginx
CMD ["nginx", "-g", "daemon off;"]
