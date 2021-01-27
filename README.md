This is based on the sample used in [Run ASP.NET Core 3 on Kubernetes with Helm](https://dev.to/wolnikmarcin/run-asp-net-core-3-on-kubernetes-with-helm-1o01) article by Marcin Wolnik. Grateful thanks for a very clear article and sample.

# Powershell typical commands (assuming Docker Desktop and Helm 3 are installed):

## cd to the solution folder

docker build -t somethingapi:v1 .

docker run --rm -it -p 8080:80 somethingapi:v1

> browse to http://localhost:8080/home/authenticate

(Ctrl+C to stop)

helm install somethingapirelease ./chart/

kubectl get all --selector app=somethingcore

kubectl port-forward service/somethingapirelease-service 9999:8888

> browse to http://localhost:9999/home/authenticate

> POST to http://localhost:9999/api/thingselse with Bearer token returned from previous service and x-www-form-url-encoded content e.g. name: example1, othername: example2

(Ctrl+C to stop)

helm uninstall somethingapirelease


