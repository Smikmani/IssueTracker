
window.chartColors = {
	red: '#808080',
	orange: 'rgb(255, 159, 64)',
	yellow: 'rgb(255, 205, 86)',
	green: 'rgb(75, 192, 192)',
	blue: 'rgb(54, 162, 235)',
	purple: 'rgb(153, 102, 255)',
	grey: 'rgb(201, 203, 207)'
};

function getPieChart(chartId, chartTitle, colors, data, labels) {
	
	var ctx = document.getElementById(chartId).getContext('2d');

	var config = {
		type: 'doughnut',
		data: {
			datasets: [{
				data,
				backgroundColor: colors,
				label: 'Dataset 1'
			}],
			labels
		},
		options: {
			responsive: true,
			legend: {
				display : false
			},
			title: {
				display: false
			},
			animation: {
				animateScale: true,
				animateRotate: true
			}
		}
	};

	var chart = new Chart(ctx, config);
}