

window.chartColors = {
	red: '#808080',
	orange: 'rgb(255, 159, 64)',
	yellow: 'rgb(255, 205, 86)',
	green: 'rgb(75, 192, 192)',
	blue: 'rgb(54, 162, 235)',
	purple: 'rgb(153, 102, 255)',
	grey: 'rgb(201, 203, 207)'
};
var config = {
	type: 'doughnut',
	data: {
		datasets: [{
			data,
			backgroundColor: [
				window.chartColors.red,
				window.chartColors.orange,
				window.chartColors.yellow
			],
			label: 'Dataset 1'
		}],
		labels
	},
	options: {
		responsive: true,
		legend: {
			position: 'top',
		},
		title: {
			display: true,
			text: 'Issue Types'
		},
		animation: {
			animateScale: true,
			animateRotate: true
		}
	}
};

window.onload = function () {
	var ctx = document.getElementById('chart-area').getContext('2d');
	window.myDoughnut = new Chart(ctx, config);
};

