<%@ page contentType="text/html;charset=utf-8" %>
<%@ page import = "java.sql.*" %>
<!doctype html>
<html>
<head>
	<title>main</title>
	<meta charset="utf-8"/>
</head>
<body>
	
	<%
	out.println("&");
	Connection conn = null;

	request.setCharacterEncoding("utf-8");
	Class.forName("com.mysql.jdbc.Driver");
	String myUrl = "jdbc:mysql://52.78.92.53:3306/game_DB";
	PreparedStatement pstmt;
	ResultSet rset;
	conn = DriverManager.getConnection(myUrl,"pooiuu","panic123");
	//ID 를 받았을때
	if(request.getParameter("ID") != null){
	String query = "select * from user_info where FB_ID = \"" + request.getParameter("ID") + "\"";
	pstmt = conn.prepareStatement(query);
	rset = pstmt.executeQuery();
	if(!rset.first()){
	out.println("No Data");
}else{
do{
out.println(rset.getString("user_id"));
out.println("\\");
out.println(rset.getString("Score"));
}while(rset.next());
}
out.println("&");

pstmt.close();
conn.close();
rset.close();
}else{
out.println("들어온 데이터 없음");
out.println("&");
}
%>

</body>