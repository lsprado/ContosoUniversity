https://azuredevopslabs.com//labs/vstsextend/ansible/

https://github.com/microsoft/azuredevopslabs/tree/master/labs/vstsextend/ansible


Logar na conta do Azure

```
az login

az account show

az account set --subscription "3323e547-1651-47e7-a768-6931436e3314"

az account list-locations -o table

```` 

# 1 - Criar uma service principal
```
az ad sp create-for-rbac --name AnsibleIAC
```

# 2 - Criar a VM Linux e instalar o ansible

```
$rgName = "RG_Ansible"
az group create -l brazilsouth -n $rgName
az deployment group create --resource-group $rgName --template-file CreateAnsibleMachine.json --parameters CreateAnsibleMachine.parameters.json --debug
```

# 3 - Conectar na maquina linux via SSH (#P@ssw0rd123456#)

```
$ipVm = az vm list-ip-addresses --resource-group $rgName --name ansible-vm-leandro --query "[].virtualMachine.network.publicIpAddresses[0].ipAddress" --output tsv

ssh leandro@$ipVm

# Atualizar a maquina
sudo apt update

# Instalar o Pip
sudo apt install python3-pip

# Instalar a blblioteca do Ansible
sudo pip install ansible[azure]
```

# 4 - Criar uma pasta .azure

```
mkdir ~/.azure
```

# 5 - Criar um arquivo Credentials com as configuracaoes do Service Principal criada no passo 1

```
nano ~/.azure/credentials

[default]
subscription_id=3323e547-1651-47e7-a768-6931436e3314
client_id=f5e7eb34-c005-4496-a7c6-69ebbc347be6
secret=pP5PtFodZlL_UDKFp8_U9IdP7JR5NqtoYn
tenant=72f988bf-86f1-41af-91ab-2d7cd011db47
```

# 6 - Gerar as chaves Privada e Publica

```
ssh-keygen -t rsa

chmod 755 ~/.ssh

touch ~/.ssh/authorized_keys

chmod 644 ~/.ssh/authorized_keys

ssh-copy-id leandro@127.0.0.1
```

# 7 - Private Key

```
cat ~/.ssh/id_rsa
```

# 8 - Criar a Service Connection no AzDevOps - SSH

# 9 - Adicionar a task do Ansible

# 10 - Instalar o pacote - fatal: [localhost]: FAILED! => {"changed": false, "msg": "Failed to import the required Python library (msrestazure) on ansible-vm-***'

```
sudo pip install msrestazure

wget -nv -q https://raw.githubusercontent.com/ansible-collections/azure/dev/requirements-azure.txt

sudo pip install -r requirements-azure.txt
```