SELECT 	pl.nome AS 'ProdutoDeLimpeza',
			al.nome AS 'Alimento',
			ROUND((ela.preco + elp.preco) * 0.85, 2) AS 'PrecoDoKit', -- Soma do preço de venda do produto e do alimento
			ROUND((ela.preco + elp.preco) * 0.85 - (ela.custo + elp.custo), 2) AS 'LucroDoKit',  -- Soma do preço de venda do produto e do alimento, diminuindo o custo de ambos
			DATE(al.data_validade) AS 'DataValidadeKit'
FROM 		supermercadohi.alimento al 
JOIN 		supermercadohi.produto_limpeza pl ON 1 = 1
JOIN 		supermercadohi.pesquisa_mercado pm ON pm.id_produto_limpeza = pl.id
JOIN 		supermercadohi.elemento_estoque elp ON elp.id = pl.id_elemento_estoque 
JOIN 		supermercadohi.elemento_estoque ela ON ela.id = al.id_elemento_estoque
WHERE 	DATEDIFF(al.data_validade, CURRENT_DATE()) < 5 -- condição para alimentos com vencimento em 05 dias
AND 		pm.satisfacao > 70 -- pesquisa de satisfação superior À 70%
ORDER BY 4 DESC; -- Ordenação pelo lucro do Kit