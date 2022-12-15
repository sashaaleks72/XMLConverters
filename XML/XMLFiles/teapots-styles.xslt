<?xml version="1.0"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
	<xsl:template match="/">
		<html>
			<head>
				<style type="text/css">
					table {
					border: 1px solid black;
					}
					table tr th {
					padding: 20px;
					border: 2px solid black;
					background: yellow;
					}
					table tr td {
					padding: 20px;
					border: 2px solid black;
					}
					table tr td p {
					text-align: center;
					font-size: 20px;
					color: green;
					}
				</style>
			</head>
			<body>
				<table>
					<tr>
						<th>Title</th>
						<th>Quantity</th>
						<th>Price</th>
						<th>ImgUrl</th>
						<th>Description</th>
						<th>ManufacturerCountry</th>
						<th>Capacity</th>
						<th>WarrantyInMonths</th>
					</tr>
					<xsl:for-each select="teapots/teapot">
						<tr>
							<td>
								<p>
									<xsl:value-of select="title"/>
								</p>
							</td>
							<td>
								<p>
									<xsl:value-of select="quantity"/>
								</p>
							</td>
							<td>
								<p>
									<xsl:value-of select="price"/>
								</p>
							</td>
							<td>
								<p>
									<xsl:value-of select="imgUrl"/>
								</p>
							</td>
							<td>
								<p>
									<xsl:value-of select="description"/>
								</p>
							</td>
							<td>
								<p>
									<xsl:value-of select="manufacturerCountry"/>
								</p>
							</td>
							<td>
								<p>
									<xsl:value-of select="capacity"/>
								</p>
							</td>
							<td>
								<p>
									<xsl:value-of select="warrantyInMonths"/>
								</p>
							</td>
						</tr>
					</xsl:for-each>
				</table>
			</body>
		</html>
	</xsl:template>
</xsl:stylesheet>