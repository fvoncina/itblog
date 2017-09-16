const Koa = require('koa');
const port = 3000;
const app = new Koa();

app.use(async (ctx, next)=>{
    ctx.body = 'Hola desde NodeJS';
});

app.listen(port, () => {
	console.log(`demo Server started on ${port}`);
});