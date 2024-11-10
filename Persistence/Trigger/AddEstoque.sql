CREATE TRIGGER AtualizarEstoqueMovimentacao
ON MovimentacoesPlantio
AFTER INSERT, UPDATE
AS
BEGIN
    DECLARE @ProdutoID INT,
            @EmpresaID INT,
            @Quantidade INT,
			@UsuarioID INT;

    SELECT @ProdutoID = p.ID,
           @EmpresaID = p.EmpresaID,
           @Quantidade = i.QntKG,
		   @UsuarioID = c.UsuarioID
    FROM inserted i
    JOIN MovimentacoesPlantio mp ON i.PlantioID = mp.PlantioID
    JOIN Colaboradores c ON c.ID = mp.ColaboradorID
    JOIN Produto p ON mp.PlantioID = p.ID;

	IF EXISTS (SELECT 1 FROM Estoque WHERE ProdutoID = @ProdutoID)
    BEGIN
        UPDATE Estoque
        SET Quantidade = Quantidade + @Quantidade
        WHERE ProdutoID = @ProdutoID;
    END
    ELSE
    BEGIN
        INSERT INTO Estoque (ProdutoID, UsuarioID, Quantidade)
        VALUES (@ProdutoID, @UsuarioID, @Quantidade);
    END
END;
