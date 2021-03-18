https://azuredevopslabs.com//labs/vstsextend/ansible/

https://github.com/microsoft/azuredevopslabs/tree/master/labs/vstsextend/ansible


az login

az account show

Conta do Azure
az account set --subscription "3323e547-1651-47e7-a768-6931436e3314"

az account list-locations -o table

# 1 - Criar uma service principal
az ad sp create-for-rbac --name AnsibleIAC

{
  "appId": "f5e7eb34-c005-4496-a7c6-69ebbc347be6",
  "displayName": "AnsibleIAC",
  "name": "http://AnsibleIAC",
  "password": "pP5PtFodZlL_UDKFp8_U9IdP7JR5NqtoYn",
  "tenant": "72f988bf-86f1-41af-91ab-2d7cd011db47"
}

# 2 - Criar a VM Linux e instalar o ansible
$rgName = "RG_Ansible"

az group create -l brazilsouth -n $rgName

az deployment group create --resource-group $rgName --template-file CreateAnsibleMachine.json --parameters CreateAnsibleMachine.parameters.json --debug

# 3 - Conectar na maquina linux via SSH
ssh leandro@191.235.92.105

# 4 - Criar uma pasta .azure
mkdir ~/.azure

# 5 - Criar um arquivo Credentials com as configuracaoes do Service Principal criada no passo 1
nano ~/.azure/credentials

[default]
subscription_id=3323e547-1651-47e7-a768-6931436e3314
client_id=f5e7eb34-c005-4496-a7c6-69ebbc347be6
secret=pP5PtFodZlL_UDKFp8_U9IdP7JR5NqtoYn
tenant=72f988bf-86f1-41af-91ab-2d7cd011db47

# 6 - Gerar as chaves Privada e Publica

ssh-keygen -t rsa

chmod 755 ~/.ssh

touch ~/.ssh/authorized_keys

chmod 644 ~/.ssh/authorized_keys

ssh-copy-id leandro@127.0.0.1

# 7 - Private Key
cat ~/.ssh/id_rsa

leandro@ansible-vm-leandro:~$ cat ~/.ssh/id_rsa
-----BEGIN RSA PRIVATE KEY-----
MIIEogIBAAKCAQEAzuoYbSjTTNTEgBOYkH4hq3pYweVBKYffrHVBT1UrsYa2jq23
Bd2U99shOLt55VCO0uoG7KRUXTQnYkPiEA4Oeak5UbH+BrLN0Qez2iYIBJDLm9k6
874PI1dV5TOqBYYA0NWekAOiFvZ+8l82xaHScG0PNShBLNGGTf5+Y8dIIWSjkRPk
xwpsrkgOIXZJYtpb6zYJckQsHpIW/BSK6o4UVejl/vH0IRO5bYGYvRPNXsdC2cGm
DnTG6E8CgxPiDrVP12BvvrVn3xbqEU5u8Wo9HGUve5ucHG+RkSET2uMcQbtIVlxa
YwvTMBTG8tSZCWa+pyUjoecnejUNIgfPUZABOQIDAQABAoIBAByVD8y8b/vUBFTg
4BlNox8J5oraPVccUtSC2gO4czGxtzQcYQTpZ/OZDIzGsP7xUtllxJEZ3iGF287i
K68mEe/SZX2YhcutFWtDkh+XU1I2IjokFtWmsnaiUNY5fcoHicNPTvj7138ui7i1
WF6SjPxExG4GYoJraw8JEbJ8y8T43wym1Ce3gnL60/4F9yiUNndMIQ9drBniMkd/
NZFRlOcuhK82eKG0BJryyYdFIcvgkONYo0we3zW6sq95xRTB3gEh8DjpfxW7HtRf
+UaScc9cyIAA3/J1mvHwGwDnkTZTQmzEj+TLRJUzJNp7jiy7or5CBnHzEuoiXzee
cayBF4ECgYEA/kM+l2iAKFADnxSfmbTQa2R2grnkkWmVdIQnninxgCv+OKuBC3pE
AeoTzrqD9s/Xx6N45ozcdDFl03DTMS44O7eVNC6cmCdI/Qrq3MVzsVx4u+Y7USWA
+D+RR5dpG4UPjZCxGkfpS5KAPeAERrN4JennNMdJXu07qGzhi+84XAkCgYEA0FQH
jrt/xXFukZTpxMm9nb4SOqN7z/7BaoPfjCsaIF9SYD948bITbwm85bFFv4L2suTM
9RmHCTQD1pW0MMNV5GQdbTHiAkXA9XARsCGCFizyTxUuhmxwfwh2PH+UTExzYPXw
kbS8aFOynyQNPfBrbiCd+SXZZagrYPml7gO7J7ECgYApXnmFmvwXEwWz0WAyWwf6
IStjE6nLuvkVLxdfFYX0i7PeNpFVc7wy74nvfctQ0fpSwhc+s7Z+tTbTEy1ZeCKw
HKuLBPZ3jxTCDw+tgfbT6a6/K7OE/Wwhd/5EPq9cSecA6oTWONMNd7Wj25n2gubO
jGMQ5EfcyQ6G1chQw0hROQKBgCBy9jplOiGm6XIDn+XnBoHreStpC3/6TmYo5EkQ
7aDdOBeFy3DaK+y/t4yPcC3EWGjE+qeysjXcxDxIVSjDRD2u2maHvoxcERIpwpeM
oJaTqapnwjdt7Jfc2Y3S0WaRAee4ZyBK5o3Ze5kOJIHhUNp2eiS0oIgVCayxNgc8
zYoBAoGAB8VfsABcpQXdrITOg667jDc3QH29xmM/B4KHzKkuAPbOh/fGsL4e/bu9
2Pw3VA/ZaDobif7lwzGH5vgbkQiIy8C9fcDrHalBgvCFhTLLMxN0fR138CjCkTZi
WoS5/AfvJc+AUgbWQzPGIZKcPLnb7LOr+aK4a439aBCtSPyQm/Q=
-----END RSA PRIVATE KEY-----

# 8 - Criar a Service Connection no AzDevOps - SSH



