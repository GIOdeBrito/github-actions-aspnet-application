
window.addEventListener('load', () => {

	console.log('Started');
	setControls();
});

function setControls ()
{
	document.querySelector('[data-name="bcall-time"]').onclick = async () => {

		const response = await fetch('http://localhost:5200/time');
		const json = await response.json();

		console.log(json);
	};

	document.querySelector('[data-name="bcall-api"]').onclick = async () => {

		const response = await fetch('http://localhost:5200/api');
		const json = await response.json();

		console.log(json);
	};
}
