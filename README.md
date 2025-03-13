# 🛒 Sistema de Pedidos – Arquitetura de Microservices  

Este projeto é um sistema de pedidos baseado em uma arquitetura de microservices, permitindo a gestão de produtos, pedidos e pagamentos de forma modular e escalável.  

## 📌 Microservices do Sistema  

### 📦 Microservice de Catálogo (CatalogService)  
Responsável por gerenciar os produtos do e-commerce.  

**Endpoints:**  
- `GET /api/produtos` → Retorna a lista de produtos.
- `GET /api/produtos/{id}` → Retorna produto por seu id.
- `POST /api/produtos` → Adiciona um novo produto.  

---  

### 🛍️ Microservice de Pedidos (OrderService)  
Responsável por processar e armazenar os pedidos dos clientes.  

**Endpoints:**  
- `POST /api/pedidos` → Cria um novo pedido.  
- `GET /api/pedidos/{id}` → Retorna detalhes do pedido.  

✅ Se comunica com o **CatalogService** para verificar disponibilidade de estoque.  

---  

### 💳 Microservice de Pagamentos (PaymentService)  
Processa os pagamentos dos pedidos.  

**Endpoints:**  
- `POST /api/pagamentos` → Processa pagamento.  
- `GET /api/pagamentos/{id}` → Consulta status do pagamento.  

✅ Se comunica com o **OrderService** para atualizar o status do pedido.  

## 🛠 Tecnologias Utilizadas  

- ✅ **ASP.NET Core** – Para construir os microservices.  
- ✅ **Swagger** – Para documentar os endpoints.
- ✅ **EntityFramework in memory** – Para armazenamento de dados.

  ## 🛠 Evolução
- ✅ **RabbitMQ** – Para comunicação assíncrona entre serviços (exemplo: pagamento confirmando pedido).  
- ✅ **Docker** – Para rodar os serviços em containers.  
- ✅ **PostgreSQL ou MongoDB** – Para armazenamento de dados.  
- ✅ **Ocelot API Gateway** – Para centralizar chamadas de API.  

## 🚀 Fluxo de Funcionamento  

1️⃣ O cliente consulta os produtos pelo **CatalogService**.  
2️⃣ Ele adiciona produtos ao carrinho e faz um pedido via **OrderService**.  
3️⃣ O **OrderService** verifica o estoque no **CatalogService** e registra o pedido.  
4️⃣ O **PaymentService** processa o pagamento e, se aprovado, notifica o **OrderService** via **RabbitMQ**.  (em fase de desenvolvimento)
5️⃣ O **OrderService** atualiza o status do pedido para **"Confirmado"**.  

---

📌 **Status:** Em desenvolvimento ⚙️  
