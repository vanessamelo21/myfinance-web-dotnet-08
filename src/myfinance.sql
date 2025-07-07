CREATE DATABASE myfinance;

USE myfinance;

CREATE TABLE planoconta (
  id INT AUTO_INCREMENT NOT NULL,
  nome VARCHAR(50) NOT NULL,
  tipo CHAR(1) NOT NULL,
  PRIMARY KEY (id)
);

CREATE TABLE transacao (
  id INT AUTO_INCREMENT NOT NULL,
  historico VARCHAR(100) NULL,
  data DATETIME NULL,
  valor DECIMAL(9,2) NULL,
  planocontaid INT NOT NULL,
  PRIMARY KEY (id),
  FOREIGN KEY (planocontaid) REFERENCES planoconta(id)
); 

-- Inserir dados na tabela planoconta
INSERT INTO planoconta (nome, tipo) VALUES ('Combustível', 'D');
INSERT INTO planoconta (nome, tipo) VALUES ('Alimentação', 'D');
INSERT INTO planoconta (nome, tipo) VALUES ('Saúde', 'D');
INSERT INTO planoconta (nome, tipo) VALUES ('Manutenção Carro', 'D');
INSERT INTO planoconta (nome, tipo) VALUES ('Viagens', 'D');
INSERT INTO planoconta (nome, tipo) VALUES ('Salário', 'R');
INSERT INTO planoconta (nome, tipo) VALUES ('Juros Recebidos', 'R');
INSERT INTO planoconta (nome, tipo) VALUES ('Créditos de Dividendos', 'R');
INSERT INTO planoconta (nome, tipo) VALUES ('Restituição de IR', 'R');

-- Consultar dados da tabela planoconta
SELECT * FROM planoconta;

-- Inserir dados na tabela transacao
INSERT INTO transacao (historico, data, valor, planocontaid) VALUES ('Combustível Blazer', NOW(), 489, 1);
INSERT INTO transacao (historico, data, valor, planocontaid) VALUES ('Almoço de Domingo', '2025-05-18 12:00', 150, 2);
INSERT INTO transacao (historico, data, valor, planocontaid) VALUES ('Peças da Blazer', '2025-05-10 03:00', 18000, 4);
INSERT INTO transacao (historico, data, valor, planocontaid) VALUES ('Salário', '2025-05-12 10:00', 10000, 6);
INSERT INTO transacao (historico, data, valor, planocontaid) VALUES ('ITAUSA', '2025-05-14 10:00', 678, 8);

-- Consultar dados da tabela transacao
SELECT * FROM transacao;